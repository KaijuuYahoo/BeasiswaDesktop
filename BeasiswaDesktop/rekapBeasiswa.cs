using System;
using System.Data;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class rekapBeasiswa : Form
    {
        DataTable dtBeasiswa;
        DataTable dtJenjang;
        DataTable dtKategori;

        public rekapBeasiswa()
        {
            InitializeComponent();
        }

        private void rekapBeasiswa_Load(object sender, EventArgs e)
        {
            dtpTanggalMasuk.Format = DateTimePickerFormat.Custom;
            dtpTanggalMasuk.CustomFormat = "MMMM";
            dtpTanggalMasuk.ShowUpDown = true;
            dtpTanggalMasuk.MinDate = new DateTime(2000, 1, 1);
            dtpTanggalMasuk.MaxDate = DateTime.Now;

            cmbJenjang.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;

            btnCetak.Enabled = false;

            try
            {
                dtJenjang = DAL.GetJenjangNames();
                cmbJenjang.DataSource = dtJenjang;
                cmbJenjang.DisplayMember = "nama_jenjang";
                cmbJenjang.ValueMember = "nama_jenjang";

                dtKategori = DAL.GetKategoriNames();
                cmbKategori.DataSource = dtKategori;
                cmbKategori.DisplayMember = "nama_kategori";
                cmbKategori.ValueMember = "nama_kategori";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string jenjang = cmbJenjang.SelectedValue?.ToString() ?? "";
                string kategori = cmbKategori.SelectedValue?.ToString() ?? "";
                int bulan = dtpTanggalMasuk.Value.Month;

                dtBeasiswa = DAL.GetReport(jenjang, kategori, bulan);
                dataGridView1.DataSource = dtBeasiswa;

                if (dtBeasiswa.Rows.Count > 0)
                {
                    btnCetak.Enabled = true;
                }
                else
                {
                    btnCetak.Enabled = false;
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
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

        private void btnCetak_Click(object sender, EventArgs e)
        {
            Cetak cetak = new Cetak(
                cmbJenjang.SelectedValue.ToString(),
                cmbKategori.SelectedValue.ToString(),
                dtpTanggalMasuk.Value);

            this.Hide();

            cetak.FormClosed += (s, args) =>
            {
                this.Show();
            };

            cetak.Show();
        }
    }
}
