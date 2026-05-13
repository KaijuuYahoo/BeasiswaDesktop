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
        public MenuAdmin(string idAdmin, string namaAdmin)
        {
            InitializeComponent();
            this.idAdmin = idAdmin;
            this.namaAdmin = namaAdmin;
        }


        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            beasiswaLoad1();
        }
        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert_Update form = new Insert_Update(0); 
            form.ShowDialog();
            beasiswaLoad1();
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBeasiswa.CurrentRow == null)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            int id = Convert.ToInt32(dgvBeasiswa.CurrentRow.Cells["id_beasiswa"].Value);

            Insert_Update form = new Insert_Update(id); 
            form.ShowDialog();
            beasiswaLoad1();
        }
        private void beasiswaLoad1()
        {
            try
            {
                Mahasiswa mhs = new Mahasiswa();
                System.Data.DataTable dt = mhs.LihatBeasiswa();

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

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    dgvBeasiswa.Rows.Add(
                        row["id_beasiswa"],
                        row["nama_beasiswa"],
                        row["nama_jenjang"],
                        row["nama_kategori"],
                        Convert.ToDateTime(row["tgl_buka"]).ToShortDateString(),
                        Convert.ToDateTime(row["tgl_tutup"]).ToShortDateString(),
                        row["link_beasiswa"],
                        row["deskripsi"]
                    );
                }

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
                    Admin admin = new Admin();
                    bool success = admin.HapusBeasiswa(id);

                    if (success)
                    {
                        MessageBox.Show("Data berhasil dihapus!");
                        beasiswaLoad1(); 
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
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.logout(this);
        }
    }
}
