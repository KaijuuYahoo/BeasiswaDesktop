using System;
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

            try
            {
                Admin admin = new Admin();
                string[] adminData = admin.login(username, password);

                if (adminData != null)
                {
                    string idAdmin = adminData[0];
                    string namaAdmin = adminData[1];

                    MessageBox.Show($"Selamat datang, {namaAdmin}!",
                        "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    MenuAdmin menuAdmin = new MenuAdmin(idAdmin, namaAdmin);
                    menuAdmin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!",
                        "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UsernameInput(object sender, EventArgs e)
        {

        }
        public void PasswordInput(object sender, EventArgs e)
        {

        }
    }
}
