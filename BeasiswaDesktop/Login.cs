using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class Login : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=RIZQI\\RIZQIMAULANA; Initial Catalog=beasiswaDB; Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
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
                if (username == "admin" && password == "admin")
                {
                    MessageBox.Show($"Selamat datang, Admin!",
                        "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MenuAdmin menuAdmin = new MenuAdmin("0", "admin");
                    menuAdmin.FormClosed += (s, args) => this.Close();
                    menuAdmin.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show($"Kamu Siapa, Rumahnya Dimana?",
                        "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
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
