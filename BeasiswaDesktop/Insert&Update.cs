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
        private readonly SqlConnection conn;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private int selectedId = 0;

        
        public Insert_Update(int id)
        {
            InitializeComponent();
            conn = Koneksi.GetConnection();
            selectedId = id;
        }

        
        private void Insert_Update_Load(object sender, EventArgs e)
        {
            LoadJenjang();
            LoadKategori();

            if (selectedId != 0)
            {
                LoadbyId();
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
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
                Beasiswa b = new Beasiswa();
                b.nama_beasiswa = namaB.Text;
                b.nama_jenjang = Convert.ToInt32(namaJ.SelectedValue);
                b.nama_kategori = Convert.ToInt32(namaK.SelectedValue);
                b.tgl_buka = dtpBuka.Value;
                b.tgl_tutup = dtpTutup.Value;
                b.link_beasiswa = link.Text;
                b.deskripsi = deskripsi.Text;

                Admin admin = new Admin();
                admin.TambahBeasiswa(b);

                MessageBox.Show("Insert berhasil!");
                ClearForm();
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
                Beasiswa b = new Beasiswa();
                b.id = selectedId;
                b.nama_beasiswa = namaB.Text;
                b.nama_jenjang = Convert.ToInt32(namaJ.SelectedValue);
                b.nama_kategori = Convert.ToInt32(namaK.SelectedValue);
                b.tgl_buka = dtpBuka.Value;
                b.tgl_tutup = dtpTutup.Value;
                b.link_beasiswa = link.Text;
                b.deskripsi = deskripsi.Text;

                Admin admin = new Admin();
                admin.EditBeasiswa(b);

                MessageBox.Show("Update berhasil!");
                this.Close();
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

