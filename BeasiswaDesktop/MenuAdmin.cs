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
        private DataTable dtBeasiswa = new DataTable();
        private readonly string connectionString =
                "Data Source=RIZQI\\RIZQIMAULANA; Initial Catalog=beasiswaDB; Integrated Security=True";


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

            int id = Convert.ToInt32(dgvBeasiswa.CurrentRow.Cells["id_beasiswa"].Value);

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
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dgvBeasiswa.DataSource = null;

                string query = "SELECT * FROM vw_Beasiswa";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgvBeasiswa.DataSource = bs;

                if (dgvBeasiswa.Columns.Contains("id_beasiswa"))
                    dgvBeasiswa.Columns["id_beasiswa"].Visible = false;
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

                    SqlCommand cmd = new SqlCommand("sp_DeleteBeasiswa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_beasiswa", id);

                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("Data berhasil dihapus!");
                    beasiswaLoad1();
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

        private void btnResetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                            IF OBJECT_ID('dbo.Beasiswa_backup') IS NOT NULL
                            BEGIN
                                DELETE FROM dbo.Beasiswa;
                                SET IDENTITY_INSERT dbo.Beasiswa ON;
                                INSERT INTO dbo.Beasiswa (id_beasiswa, nama_beasiswa, id_jenjang, id_kategori, tgl_buka, tgl_tutup, link_beasiswa, deskripsi, dibuat)
                                SELECT id_beasiswa, nama_beasiswa, id_jenjang, id_kategori, tgl_buka, tgl_tutup, link_beasiswa, deskripsi, dibuat FROM dbo.Beasiswa_backup;
                                SET IDENTITY_INSERT dbo.Beasiswa OFF;
                            END";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
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
