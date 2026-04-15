using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class MenuAdmin : Form
    {
        private readonly string idAdmin;
        private readonly string namaAdmin;
        private readonly SqlConnection conn;
        private readonly string connectionString =
                "Data Source=LAPTOP-QEMA84FU\\HOME;Initial Catalog=beasiswaDB;Integrated Security=True";

        public MenuAdmin(string idAdmin, string namaAdmin)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.idAdmin = idAdmin;
            this.namaAdmin = namaAdmin;
        }


        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            beasiswaLoad1();
        }
        // ================= INSERT =================
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert_Update form = new Insert_Update(0); // mode insert
            form.ShowDialog();
            beasiswaLoad1();
        }

        // ================= EDIT =================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBeasiswa.CurrentRow == null)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            int id = Convert.ToInt32(dgvBeasiswa.CurrentRow.Cells["id_beasiswa"].Value);

            Insert_Update form = new Insert_Update(id); // mode update
            form.ShowDialog();
            beasiswaLoad1();
        }
        private void beasiswaLoad1()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dgvBeasiswa.Rows.Clear();
                dgvBeasiswa.Columns.Clear();

                dgvBeasiswa.Columns.Add("id_beasiswa", "ID");
                dgvBeasiswa.Columns.Add("nama_beasiswa", "Nama Beasiswa");
                dgvBeasiswa.Columns.Add("nama_jenjang", "Jenjang");
                dgvBeasiswa.Columns.Add("nama_kategori", "Kategori");
                dgvBeasiswa.Columns.Add("tgl_buka", "Tgl Buka");
                dgvBeasiswa.Columns.Add("tgl_tutup", "Tgl Tutup");
                dgvBeasiswa.Columns.Add("link_beasiswa", "Link");
                dgvBeasiswa.Columns.Add("deskripsi", "Deskripsi");

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

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvBeasiswa.Rows.Add(
                        reader["id_beasiswa"],
                        reader["nama_beasiswa"],
                        reader["nama_jenjang"],
                        reader["nama_kategori"],
                        Convert.ToDateTime(reader["tgl_buka"]).ToShortDateString(),
                        Convert.ToDateTime(reader["tgl_tutup"]).ToShortDateString(),
                        reader["link_beasiswa"],
                        reader["deskripsi"]
                    );
                }

                reader.Close();

                dgvBeasiswa.Columns["id_beasiswa"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBeasiswa.CurrentRow == null)
                {
                    MessageBox.Show("Pilih data yang ingin dihapus!");
                    return;
                }

                int id = Convert.ToInt32(dgvBeasiswa.CurrentRow.Cells["id_beasiswa"].Value);
                string nama = dgvBeasiswa.CurrentRow.Cells["nama_beasiswa"].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Yakin ingin menghapus data:\n{nama} ?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "DELETE FROM Beasiswa WHERE id_beasiswa = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus!");
                        beasiswaLoad1(); // refresh grid
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
