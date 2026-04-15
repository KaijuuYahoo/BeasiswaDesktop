using System;
using System.Data;
using System.Data.SqlClient;

namespace BeasiswaDesktop
{
    public class Mahasiswa
    {
        
        public DataTable LihatBeasiswa()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"
                SELECT 
                    b.id_beasiswa,
                    b.nama_beasiswa,
                    j.nama_jenjang,
                    k.nama_kategori,
                    b.tgl_buka,
                    b.tgl_tutup,
                    b.link_beasiswa,
                    b.deskripsi
                FROM Beasiswa b
                JOIN Jenjang j ON b.id_jenjang = j.id_jenjang
                JOIN Kategori k ON b.id_kategori = k.id_kategori";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lihat data error: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public DataTable CariBeasiswa(string keyword)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                string query = @"
                SELECT 
                    b.nama_beasiswa,
                    j.nama_jenjang,
                    k.nama_kategori,
                    b.tgl_buka,
                    b.tgl_tutup,
                    b.link_beasiswa,
                    b.deskripsi
                FROM Beasiswa b
                JOIN Jenjang j ON b.id_jenjang = j.id_jenjang
                JOIN Kategori k ON b.id_kategori = k.id_kategori
                WHERE 
                    b.nama_beasiswa LIKE @keyword OR
                    j.nama_jenjang LIKE @keyword OR
                    k.nama_kategori LIKE @keyword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Cari data error: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}
