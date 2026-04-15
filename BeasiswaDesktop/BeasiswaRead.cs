using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class BeasiswaRead : Form
    { 
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=LAPTOP-QEMA84FU\\HOME;Initial Catalog=beasiswaDB;Integrated Security=True";
        public BeasiswaRead()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void BeasiswaRead_Load(object sender, EventArgs e)
        {
            beasiswaLoad();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void beasiswaLoad()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                dgvBeasiswa.Rows.Clear();
                dgvBeasiswa.Columns.Clear();

                dgvBeasiswa.Columns.Add("nama_beasiswa", "Nama Beasiswa");
                dgvBeasiswa.Columns.Add("nama_jenjang", "Nama Jenjang");
                dgvBeasiswa.Columns.Add("nama_kategori", "Nama Kategori");
                dgvBeasiswa.Columns.Add("tgl_buka", "Tanggal Buka");
                dgvBeasiswa.Columns.Add("tgl_tutup", "Tanggal Tutup");
                dgvBeasiswa.Columns.Add("link_beasiswa", "Link");
                dgvBeasiswa.Columns.Add("deskripsi", "Deskripsi");

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
                        JOIN Kategori k ON b.id_kategori = k.id_kategori";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvBeasiswa.Rows.Add(
                        reader["nama_beasiswa"].ToString(),
                        reader["nama_jenjang"].ToString(),
                        reader["nama_kategori"].ToString(),
                        Convert.ToDateTime(reader["tgl_buka"]).ToShortDateString(),
                        Convert.ToDateTime(reader["tgl_tutup"]).ToShortDateString(),
                        reader["link_beasiswa"].ToString(),
                        reader["deskripsi"].ToString()
                    );
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
                string keyword = textSearch.Text.Trim();

                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();

                    dgvBeasiswa.Rows.Clear();

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

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvBeasiswa.Rows.Add(
                            reader["nama_beasiswa"].ToString(),
                            reader["nama_jenjang"].ToString(),
                            reader["nama_kategori"].ToString(),
                            Convert.ToDateTime(reader["tgl_buka"]).ToShortDateString(),
                            Convert.ToDateTime(reader["tgl_tutup"]).ToShortDateString(),
                            reader["link_beasiswa"].ToString(),
                            reader["deskripsi"].ToString()
                        );
                    }

                    reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal search: " + ex.Message);
            }
        }

        private void SearchText(object sender, EventArgs e)
        {

        }
    }
}
