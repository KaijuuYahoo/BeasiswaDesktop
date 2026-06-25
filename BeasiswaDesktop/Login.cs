using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginDenganSP(string username, string password)
        {
            try
            {
                string namaUser = DAL.LoginDenganSP(username, password);

                if (namaUser != null)
                {
                    MessageBox.Show(
                        $"Selamat datang, {namaUser}!",
                        "Login Berhasil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    MenuAdmin menuAdmin = new MenuAdmin("0", "admin");
                    menuAdmin.FormClosed += (s, args) => this.Close();
                    menuAdmin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Username atau password salah.",
                        "Login Gagal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Gagal terhubung ke database:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Terjadi error tidak terduga:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginTanpaSP()
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            try
            {
                string namaUser = DAL.LoginTanpaSP(username, password);

                if (namaUser != null)
                {
                    MessageBox.Show(
                        $" Login berhasil: {namaUser}", " Login Berhasil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    MenuAdmin menuAdmin = new MenuAdmin("0", "admin");
                    menuAdmin.FormClosed += (s, args) => this.Close();
                    menuAdmin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Username atau password salah.",
                        "Login Gagal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Error SQL:\n{ex.Message}\n\nIni mungkin efek SQL Injection!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Login_Button(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CheckBoxSLQi.Checked == true)
            {
                LoginTanpaSP();
               
            }
            else if (CheckBoxSLQi.Checked == false)
            {
                LoginDenganSP(username, password);
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

        public void UsernameInput(object sender, EventArgs e) { }
        public void PasswordInput(object sender, EventArgs e) { }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}