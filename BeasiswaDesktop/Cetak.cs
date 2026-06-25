using System;
using System.Data;
using System.Windows.Forms;

namespace BeasiswaDesktop
{
    public partial class Cetak : Form
    {
        DataTable dtBeasiswa;
        BeasiswaReport ReportBeasiswa = new BeasiswaReport();

        string namaJenjang { get; set; }
        string namaKategori { get; set; }
        DateTime TglMsuk {  get; set; }  

        public Cetak(string namaJenjang, string namaKategori, DateTime TglMsuk)
        {
            InitializeComponent();

            this.namaJenjang = namaJenjang;
            this.namaKategori = namaKategori;
            this.TglMsuk = TglMsuk;
            try
            {
                dtBeasiswa = DAL.GetReport(namaJenjang, namaKategori, TglMsuk.Month);
                ReportBeasiswa.SetDataSource(dtBeasiswa);
                crystalReportViewer1.ReportSource = ReportBeasiswa;
                crystalReportViewer1.Refresh();
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
    }
}
