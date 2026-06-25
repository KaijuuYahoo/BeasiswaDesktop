using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class Insert_Update : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private int selectedId = 0;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public Insert_Update(int id)
        {
            InitializeComponent();
            selectedId = id;
            namaJ.DropDownStyle = ComboBoxStyle.DropDownList;
            namaK.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Insert_Update_Load(object sender, EventArgs e)
        {
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
                DataTable dt = DAL.GetAllBeasiswa();

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
                DataTable dt = DAL.GetJenjangList();

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
                DataTable dt = DAL.GetKategoriList();

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
                DataTable dt = DAL.GetBeasiswaById(selectedId);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    namaB.Text = r["nama_beasiswa"].ToString();

                    int jenjang = Convert.ToInt32(r["id_jenjang"]);
                    int kategori = Convert.ToInt32(r["id_kategori"]);

                    dtpBuka.Value = Convert.ToDateTime(r["tgl_buka"]);
                    dtpTutup.Value = Convert.ToDateTime(r["tgl_tutup"]);
                    link.Text = r["link_beasiswa"].ToString();
                    deskripsi.Text = r["deskripsi"].ToString();

                    namaJ.SelectedValue = jenjang;
                    namaK.SelectedValue = kategori;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(namaB.Text))
            {
                MessageBox.Show("Nama beasiswa harus diisi!");
                namaB.Focus();
                return false;
            }

            if (namaJ.SelectedValue == null ||
                Convert.ToInt32(namaJ.SelectedValue) == 0)
            {
                MessageBox.Show("Pilih jenjang!");
                namaJ.Focus();
                return false;
            }

            if (namaK.SelectedValue == null ||
                Convert.ToInt32(namaK.SelectedValue) == 0)
            {
                MessageBox.Show("Pilih kategori!");
                namaK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(link.Text))
            {
                MessageBox.Show("Link beasiswa harus diisi!");
                link.Focus();
                return false;
            }

            if (!link.Text.StartsWith("https://"))
            {
                MessageBox.Show("Link harus diawali https://");
                link.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(deskripsi.Text))
            {
                MessageBox.Show("Deskripsi harus diisi!");
                deskripsi.Focus();
                return false;
            }

            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput())
                return;

            try
            {
                string nama = namaB.Text;
                int idJenjang = Convert.ToInt32(namaJ.SelectedValue);
                int idKategori = Convert.ToInt32(namaK.SelectedValue);
                DateTime tglBuka = dtpBuka.Value;
                DateTime tglTutup = dtpTutup.Value;
                string linkVal = link.Text;
                string deskripsiVal = deskripsi.Text;

                DAL.InsertBeasiswa(nama, idJenjang, idKategori, tglBuka, tglTutup, linkVal, deskripsiVal);

                MessageBox.Show("Data berhasil ditambahkan");
                
                ClearForm();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error : " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = namaB.Text;
                int idJenjang = Convert.ToInt32(namaJ.SelectedValue);
                int idKategori = Convert.ToInt32(namaK.SelectedValue);
                DateTime tglBuka = dtpBuka.Value;
                DateTime tglTutup = dtpTutup.Value;
                string linkVal = link.Text;
                string deskripsiVal = deskripsi.Text;

                int result = DAL.UpdateBeasiswa(selectedId, nama, idJenjang, idKategori, tglBuka, tglTutup, linkVal, deskripsiVal);
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
                int result = DAL.UpdateBeasiswaUnsafe(deskripsi.Text, namaB.Text);
                MessageBox.Show(result + " baris terupdate");
                Insert_Update_Load(sender, e);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable excelData;

        private void btnImpEx_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(ofd.FileName,
                                                  FileMode.Open,
                                                  FileAccess.Read))
                    {
                        using (var reader =
                            ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(
                                new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable =
                                        (_) => new ExcelDataTableConfiguration()
                                        {
                                            UseHeaderRow = true
                                        }
                                });

                            excelData = result.Tables[0];

                            MessageBox.Show(
                                excelData.Rows.Count +
                                " data berhasil dibaca dari Excel");
                        }
                    }
                }
            }
        }

        private void btnImpDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (excelData == null || excelData.Rows.Count == 0)
                {
                    MessageBox.Show("Belum ada file Excel yang diimport.");
                    return;
                }

                int sukses = 0;

                foreach (DataRow row in excelData.Rows)
                {
                    string nama = row["NamaBeasiswa"].ToString();
                    string jenjang = row["Jenjang"].ToString();
                    string kategori = row["Kategori"].ToString();
                    DateTime tglBuka = Convert.ToDateTime(row["TglBuka"]);
                    DateTime tglTutup = Convert.ToDateTime(row["TglTutup"]);
                    string linkVal = row["LinkBeasiswa"].ToString();
                    string deskripsiVal = row["Deskripsi"].ToString();

                    int idJenjang = DAL.GetJenjangIdByName(jenjang);
                    int idKategori = DAL.GetKategoriIdByName(kategori);

                    DAL.InsertBeasiswaSimple(nama, idJenjang, idKategori, tglBuka, tglTutup, linkVal, deskripsiVal);

                    sukses++;
                }

                MessageBox.Show(sukses + " data berhasil diimport ke database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
