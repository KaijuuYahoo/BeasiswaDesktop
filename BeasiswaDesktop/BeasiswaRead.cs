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
            HitungTotal();
        }

        private void LiveSearch(object sender, EventArgs e)
        {
            string keyword = textSearch.Text.Trim();

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString)) 
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter("sp_SearchBeasiswa", conn))
                        {
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand.Parameters.AddWithValue("@keyword", keyword);

                            dtBeasiswa = new DataTable();

                            da.Fill(dtBeasiswa);

                            dgvBeasiswa.DataSource = dtBeasiswa;
                        }
                    }
                    
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountBeasiswa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblTotal.Text = "Total Beasiswa: " + outputParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
            }
        }
    }
}
