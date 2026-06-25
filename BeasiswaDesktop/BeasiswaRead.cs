using System;
using System.Data;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class BeasiswaRead : Form
    {
        private DataTable dtBeasiswa = new DataTable();

        public BeasiswaRead()
        {
            InitializeComponent();
            textSearch.TextChanged += SearchAutomatic;
            BeasiswaRead_Load(this, EventArgs.Empty);
        }

        private void BeasiswaRead_Load(object sender, EventArgs e)
        {
            beasiswaLoad();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    BeasiswaRead_Load(s, args);
                };
            this.Hide();
            loginForm.Show();
        }

        private void beasiswaLoad()
        {
            try
            {
                dtBeasiswa = DAL.GetVwBeasiswa2();
                dgvBeasiswa.DataSource = dtBeasiswa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
            HitungTotal();
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

        private void SearchAutomatic(object sender, EventArgs e)
        {
            LiveSearch(sender, e);
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
    }
}
