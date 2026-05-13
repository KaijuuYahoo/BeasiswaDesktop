using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BeasiswaDesktop
{
    public partial class BeasiswaRead : Form
    { 
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=RIZQI\\RIZQIMAULANA; Initial Catalog=beasiswaDB; Integrated Security=True";
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                   conn.Open();
                    string query = "SELECT * FROM vw_Beasiswa2";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtBeasiswa = new DataTable();

                        da.Fill(dtBeasiswa);

                        dgvBeasiswa.DataSource = dtBeasiswa;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        private void LiveSearch(object sender, EventArgs e)
        {
            string keyword = textSearch.Text.Trim();

                
        }

        private void SearchAutomatic(object sender, EventArgs e)
        {
            LiveSearch(sender, e);
        }
    }
}
