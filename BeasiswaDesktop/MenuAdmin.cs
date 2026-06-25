using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private DataTable dtBeasiswa = new DataTable();

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
            this.Hide();
            Insert_Update form = new Insert_Update(0);
            form.ShowDialog();
            beasiswaLoad1();
            this.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBeasiswa.CurrentRow == null)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            int id = Convert.ToInt32(dgvBeasiswa.CurrentRow.Cells["ID"].Value);

            this.Hide();
            Insert_Update form = new Insert_Update(id);
            form.ShowDialog();
            beasiswaLoad1();
            this.Show();
        }

        private void beasiswaLoad1()
        {
            try
            {
                dgvBeasiswa.DataSource = null;

                DataTable dt = DAL.GetVwBeasiswa();

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgvBeasiswa.DataSource = bs;

                if (dgvBeasiswa.Columns.Contains("ID"))
                    dgvBeasiswa.Columns["ID"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            HitungTotal();
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

                int id = Convert.ToInt32(dgvBeasiswa.CurrentRow.Cells["ID"].Value);
                string nama = dgvBeasiswa.CurrentRow.Cells["Nama Beasiswa"].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Yakin ingin menghapus data:\n{nama} ?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    DAL.DeleteBeasiswa(id);
                    
                    MessageBox.Show("Data berhasil dihapus!");
                    beasiswaLoad1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LiveSearch(object sender, EventArgs e)
        {
            string keyword = textSearch.Text.Trim();

            try
            {
                dtBeasiswa = DAL.SearchBeasiswa(keyword);
                dgvBeasiswa.DataSource = dtBeasiswa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal search: " + ex.Message);
            }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.ResetBeasiswaData();
                MessageBox.Show("Data berhasil direset");
                beasiswaLoad1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }

        private void SearchAutomatic(object sender, EventArgs e)
        {
            LiveSearch(sender, e);
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin log out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void HitungTotal()
        {
            try
            {
                int total = DAL.GetTotalBeasiswa();
                lblTotal.Text = "Total Beasiswa: " + total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
            }
        }

        public static string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP address:" + ex.Message);
            }
            return localIP;
        }

        private void btnRekap_Click(object sender, EventArgs e)
        {
            rekapBeasiswa rekap = new rekapBeasiswa();

            this.Hide();

            rekap.FormClosed += (s, args) =>
            {
                this.Show();
            };

            rekap.Show();
        }
    }
}
