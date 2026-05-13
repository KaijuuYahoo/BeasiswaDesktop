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
    public partial class Insert_Update : Form
    {
        private BindingSource bindingSource = new BindingSource();

        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=RIZQI\\RIZQIMAULANA; Initial Catalog=beasiswaDB; Integrated Security=True";

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private int selectedId = 0;

        public Insert_Update(int id)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            selectedId = id;
            namaJ.DropDownStyle = ComboBoxStyle.DropDownList;
            namaK.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Insert_Update_Load(object sender, EventArgs e)
        {
            this.kategoriTableAdapter.Fill(this.beasiswaDBDataSet.Kategori);
            this.jenjangTableAdapter.Fill(this.beasiswaDBDataSet.Jenjang);
            this.beasiswaTableAdapter.Fill(this.beasiswaDBDataSet.Beasiswa);
            LoadJenjang();
            LoadKategori();

            BindControls();

            if (selectedId != 0)
            {
                LoadbyId();
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                bindingSource.AddNew();
                
                dtpBuka.Value = DateTime.Today;
                dtpBuka.MinDate = DateTime.Today;
                
                dtpTutup.Value = dtpBuka.Value.AddYears(1);
                
                button1.Enabled = true;
                button2.Enabled = false;
            }

            dtpTutup.MinDate = dtpBuka.Value;
            dtpTutup.MaxDate = dtpBuka.Value.AddYears(1);
        }

        private void BindControls()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Beasiswa", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bindingSource.DataSource = dt;

                bindingNavigator1.BindingSource = bindingSource;
                bindingNavigator1.DeleteItem = null;

                namaB.DataBindings.Clear();
                namaJ.DataBindings.Clear();
                namaK.DataBindings.Clear();
                dtpBuka.DataBindings.Clear();
                dtpTutup.DataBindings.Clear();
                link.DataBindings.Clear();
                deskripsi.DataBindings.Clear();

                namaB.DataBindings.Add("Text", bindingSource, "nama_beasiswa", true, DataSourceUpdateMode.Never);
                namaJ.DataBindings.Add("SelectedValue", bindingSource, "id_jenjang", true, DataSourceUpdateMode.Never);
                namaK.DataBindings.Add("SelectedValue", bindingSource, "id_kategori", true, DataSourceUpdateMode.Never);
                dtpBuka.DataBindings.Add("Value", bindingSource, "tgl_buka", true, DataSourceUpdateMode.Never);
                dtpTutup.DataBindings.Add("Value", bindingSource, "tgl_tutup", true, DataSourceUpdateMode.Never);
                link.DataBindings.Add("Text", bindingSource, "link_beasiswa", true, DataSourceUpdateMode.Never);
                deskripsi.DataBindings.Add("Text", bindingSource, "deskripsi", true, DataSourceUpdateMode.Never);

                bindingSource.PositionChanged += (s, e) => {
                    DataRowView current = (DataRowView)bindingSource.Current;
                    if (current != null && current["id_beasiswa"] != DBNull.Value)
                    {
                        selectedId = Convert.ToInt32(current["id_beasiswa"]);
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                    else
                    {
                        selectedId = 0;
                        button1.Enabled = true;
                        button2.Enabled = false;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BindingNavigator: " + ex.Message);
            }
        }

        private void LoadJenjang()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT id_jenjang, nama_jenjang FROM Jenjang";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
                row["id_jenjang"] = 0;
                row["nama_jenjang"] = "-- Pilih Jenjang --";
                dt.Rows.InsertAt(row, 0);

                namaJ.DataSource = dt;
                namaJ.DisplayMember = "nama_jenjang";
                namaJ.ValueMember = "id_jenjang";
                namaJ.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Jenjang: " + ex.Message);
            }
        }

        private void LoadKategori()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT id_kategori, nama_kategori FROM Kategori";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
                row["id_kategori"] = 0;
                row["nama_kategori"] = "-- Pilih Kategori --";
                dt.Rows.InsertAt(row, 0);

                namaK.DataSource = dt;
                namaK.DisplayMember = "nama_kategori";
                namaK.ValueMember = "id_kategori";
                namaK.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Kategori: " + ex.Message);
            }
        }

        private void LoadbyId()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Beasiswa WHERE id_beasiswa=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedId);

                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    namaB.Text = r["nama_beasiswa"].ToString();

                    int jenjang = Convert.ToInt32(r["id_jenjang"]);
                    int kategori = Convert.ToInt32(r["id_kategori"]);

                    dtpBuka.Value = Convert.ToDateTime(r["tgl_buka"]);
                    dtpTutup.Value = Convert.ToDateTime(r["tgl_tutup"]);
                    link.Text = r["link_beasiswa"].ToString();
                    deskripsi.Text = r["deskripsi"].ToString();

                    r.Close();

                    namaJ.SelectedValue = jenjang;
                    namaK.SelectedValue = kategori;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Insert_Update form = new Insert_Update(0);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertBeasiswa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nama_beasiswa", namaB.Text);
                cmd.Parameters.AddWithValue("@id_jenjang", namaJ.SelectedValue);
                cmd.Parameters.AddWithValue("@id_kategori", namaK.SelectedValue);
                cmd.Parameters.AddWithValue("@tgl_buka", dtpBuka.Value);
                cmd.Parameters.AddWithValue("@tgl_tutup", dtpTutup.Value);
                cmd.Parameters.AddWithValue("@link_beasiswa", link.Text);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Insert berhasil!");
                ClearForm();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("sp_UpdateBeasiswa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_beasiswa", selectedId);
                cmd.Parameters.AddWithValue("@nama_beasiswa", namaB.Text);
                cmd.Parameters.AddWithValue("@id_jenjang", namaJ.SelectedValue);
                cmd.Parameters.AddWithValue("@id_kategori", namaK.SelectedValue);
                cmd.Parameters.AddWithValue("@tgl_buka", dtpBuka.Value);
                cmd.Parameters.AddWithValue("@tgl_tutup", dtpTutup.Value);
                cmd.Parameters.AddWithValue("@link_beasiswa", link.Text);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi.Text);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    MessageBox.Show("Update gagal: data tidak ditemukan.");
                    return;
                }
                else
                {
                    MessageBox.Show("Update berhasil!");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            namaB.Clear();
            link.Clear();
            deskripsi.Clear();
            namaJ.SelectedIndex = -1;
            namaK.SelectedIndex = -1;
        }
        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query =
                        "UPDATE Beasiswa SET deskripsi='HACKED' WHERE nama_beasiswa='" +
                        namaB.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris terupdate");
                        Insert_Update_Load(sender, e);
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboKategori(object sender, EventArgs e)
        {

        }

        private void namaJ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void namaK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

