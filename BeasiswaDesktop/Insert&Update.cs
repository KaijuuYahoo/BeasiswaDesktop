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
        private readonly string connectionString =
            "Data Source=LAPTOP-QEMA84FU\\HOME;Initial Catalog=beasiswaDB;Integrated Security=True";

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private int selectedId = 0;

        // ================= CONSTRUCTOR =================
        public Insert_Update(int id)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            selectedId = id;
        }

        // ================= LOAD =================
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

        // ================= COMBO =================
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
                row["id_jenjang"] = 0; // GANTI dari DBNull
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
                row["id_kategori"] = 0; // GANTI
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

        // ================= LOAD DATA EDIT =================
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

                    // 🔥 WAJIB: pastikan value ada
                    namaJ.SelectedValue = jenjang;
                    namaK.SelectedValue = kategori;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= INSERT =================
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"INSERT INTO Beasiswa
                (nama_beasiswa,id_jenjang,id_kategori,tgl_buka,tgl_tutup,link_beasiswa,deskripsi)
                VALUES(@B,@J,@K,@TB,@TT,@L,@D)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@B", namaB.Text);
                cmd.Parameters.AddWithValue("@J", namaJ.SelectedValue);
                cmd.Parameters.AddWithValue("@K", namaK.SelectedValue);
                cmd.Parameters.AddWithValue("@TB", dtpBuka.Value);
                cmd.Parameters.AddWithValue("@TT", dtpTutup.Value);
                cmd.Parameters.AddWithValue("@L", link.Text);
                cmd.Parameters.AddWithValue("@D", deskripsi.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Insert berhasil!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"UPDATE Beasiswa SET
                nama_beasiswa=@B,
                id_jenjang=@J,
                id_kategori=@K,
                tgl_buka=@TB,
                tgl_tutup=@TT,
                link_beasiswa=@L,
                deskripsi=@D
                WHERE id_beasiswa=@ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", selectedId);
                cmd.Parameters.AddWithValue("@B", namaB.Text);
                cmd.Parameters.AddWithValue("@J", namaJ.SelectedValue);
                cmd.Parameters.AddWithValue("@K", namaK.SelectedValue);
                cmd.Parameters.AddWithValue("@TB", dtpBuka.Value);
                cmd.Parameters.AddWithValue("@TT", dtpTutup.Value);
                cmd.Parameters.AddWithValue("@L", link.Text);
                cmd.Parameters.AddWithValue("@D", deskripsi.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Update berhasil!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= CLEAR =================
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

