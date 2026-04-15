using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class Login : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=LAPTOP-QEMA84FU\\HOME;Initial Catalog=beasiswaDB;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void Login_Button(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Validasi input kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = "SELECT IDAdmin, username FROM Admin WHERE username = @username AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string idAdmin = reader["IDAdmin"].ToString();
                            string namaAdmin = reader["username"].ToString();

                            MessageBox.Show($"Selamat datang, {namaAdmin}!",
                                "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Buka form utama & tutup form login
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
