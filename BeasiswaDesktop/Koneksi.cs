using System;
using System.Data.SqlClient;

namespace BeasiswaDesktop
{
    public static class Koneksi
    {
        private static readonly string connectionString = "Data Source=LAPTOP-QEMA84FU\\HOME;Initial Catalog=beasiswaDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
