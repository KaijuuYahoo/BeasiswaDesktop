using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // Need this for DialogResult if we strictly follow the diagram for logout, or just basic boolean

namespace BeasiswaDesktop
{
    public class Admin
    {
        private int id { get; set; }
        private string username { get; set; }
        private string password { get; set; }

        // Menerima input username & password dari UI, mengembalikan array (idAdmin, username) atau null
        public string[] login(string user, string pass)
        {
            string[] result = null;
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                string query = "SELECT IDAdmin, username FROM Admin WHERE username = @username AND password = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user);
                    cmd.Parameters.AddWithValue("@password", pass);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                this.id = Convert.ToInt32(reader["IDAdmin"]);
                                this.username = reader["username"].ToString();

                                result = new string[2];
                                result[0] = reader["IDAdmin"].ToString();
                                result[1] = this.username;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Login error: " + ex.Message);
                    }
                }
            }
            return result;
        }

        public void logout(Form menuAdminForm)
        {
            DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin log out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                menuAdminForm.Close();
            }
        }

        public void TambahBeasiswa(Beasiswa b)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"INSERT INTO Beasiswa
                (nama_beasiswa, id_jenjang, id_kategori, tgl_buka, tgl_tutup, link_beasiswa, deskripsi)
                VALUES(@B, @J, @K, @TB, @TT, @L, @D)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@B", b.nama_beasiswa);
                    cmd.Parameters.AddWithValue("@J", b.nama_jenjang); // Using nama_jenjang as id based on your Class Diagram mapping
                    cmd.Parameters.AddWithValue("@K", b.nama_kategori);
                    cmd.Parameters.AddWithValue("@TB", b.tgl_buka);
                    cmd.Parameters.AddWithValue("@TT", b.tgl_tutup);
                    cmd.Parameters.AddWithValue("@L", b.link_beasiswa);
                    cmd.Parameters.AddWithValue("@D", b.deskripsi);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Tambah error: " + ex.Message);
                    }
                }
            }
        }

        public void EditBeasiswa(Beasiswa b)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"UPDATE Beasiswa SET
                nama_beasiswa=@B,
                id_jenjang=@J,
                id_kategori=@K,
                tgl_buka=@TB,
                tgl_tutup=@TT,
                link_beasiswa=@L,
                deskripsi=@D
                WHERE id_beasiswa=@ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", b.id);
                    cmd.Parameters.AddWithValue("@B", b.nama_beasiswa);
                    cmd.Parameters.AddWithValue("@J", b.nama_jenjang);
                    cmd.Parameters.AddWithValue("@K", b.nama_kategori);
                    cmd.Parameters.AddWithValue("@TB", b.tgl_buka);
                    cmd.Parameters.AddWithValue("@TT", b.tgl_tutup);
                    cmd.Parameters.AddWithValue("@L", b.link_beasiswa);
                    cmd.Parameters.AddWithValue("@D", b.deskripsi);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Edit error: " + ex.Message);
                    }
                }
            }
        }

        public bool HapusBeasiswa(int deleteId)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                string query = "DELETE FROM Beasiswa WHERE id_beasiswa = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", deleteId);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Delete error: " + ex.Message);
                    }
                }
            }
        }
    }
}
