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
    public partial class BeasiswaRead : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source= DESKTOP-C6LEFON\\KAIJUURUN;Initial Catalog= ;Integrated Security=True";
        public BeasiswaRead()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void BeasiswaRead_Load(object sender, EventArgs e)
        {

        }
    }
}
