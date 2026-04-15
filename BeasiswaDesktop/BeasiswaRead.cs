using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class BeasiswaRead : Form
    { 
        public BeasiswaRead()
        {
            InitializeComponent();
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
                Mahasiswa mhs = new Mahasiswa();
                System.Data.DataTable dt = mhs.LihatBeasiswa();

                dgvBeasiswa.Rows.Clear();
                dgvBeasiswa.Columns.Clear();

                dgvBeasiswa.Columns.Add("nama_beasiswa", "Nama Beasiswa");
                dgvBeasiswa.Columns.Add("nama_jenjang", "Nama Jenjang");
                dgvBeasiswa.Columns.Add("nama_kategori", "Nama Kategori");
                dgvBeasiswa.Columns.Add("tgl_buka", "Tanggal Buka");
                dgvBeasiswa.Columns.Add("tgl_tutup", "Tanggal Tutup");
                dgvBeasiswa.Columns.Add("link_beasiswa", "Link");
                dgvBeasiswa.Columns.Add("deskripsi", "Deskripsi");

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    dgvBeasiswa.Rows.Add(
                        row["nama_beasiswa"].ToString(),
                        row["nama_jenjang"].ToString(),
                        row["nama_kategori"].ToString(),
                        Convert.ToDateTime(row["tgl_buka"]).ToShortDateString(),
                        Convert.ToDateTime(row["tgl_tutup"]).ToShortDateString(),
                        row["link_beasiswa"].ToString(),
                        row["deskripsi"].ToString()
                    );
                }
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
                    Mahasiswa mhs = new Mahasiswa();
                    System.Data.DataTable dt = mhs.CariBeasiswa(keyword);

                    dgvBeasiswa.Rows.Clear();

                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        dgvBeasiswa.Rows.Add(
                            row["nama_beasiswa"].ToString(),
                            row["nama_jenjang"].ToString(),
                            row["nama_kategori"].ToString(),
                            Convert.ToDateTime(row["tgl_buka"]).ToShortDateString(),
                            Convert.ToDateTime(row["tgl_tutup"]).ToShortDateString(),
                            row["link_beasiswa"].ToString(),
                            row["deskripsi"].ToString()
                        );
                    }
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
