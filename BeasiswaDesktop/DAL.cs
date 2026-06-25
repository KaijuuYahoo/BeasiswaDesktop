using System;
using System.Data;
using System.Data.SqlClient;

namespace BeasiswaDesktop
{
    public static class DAL
    {
        private static readonly string connectionString =
            @"Data Source=Rizqi\RIZQIMAULANA,1433; Initial Catalog=beasiswaDB; User ID=sa; Password=password123; TrustServerCertificate=True";

        /// <summary>
        /// Melakukan login dengan memanggil Stored Procedure sp_Login.
        /// </summary>
        public static string LoginDenganSP(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            return reader["Username"].ToString();
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Melakukan login langsung tanpa Stored Procedure (Raw SQL query, demo SQL Injection).
        /// </summary>
        public static string LoginTanpaSP(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            return reader["Username"].ToString();
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Mengambil data dari view vw_Beasiswa.
        /// </summary>
        public static DataTable GetVwBeasiswa()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vw_Beasiswa";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Mengambil data dari view vw_Beasiswa2.
        /// </summary>
        public static DataTable GetVwBeasiswa2()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vw_Beasiswa2";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Menghapus data beasiswa dengan memanggil sp_DeleteBeasiswa.
        /// </summary>
        public static void DeleteBeasiswa(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteBeasiswa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_beasiswa", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Mencari data beasiswa dengan memanggil sp_SearchBeasiswa.
        /// </summary>
        public static DataTable SearchBeasiswa(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("sp_SearchBeasiswa", conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@keyword", keyword);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Melakukan reset data ke cadangan Beasiswa_backup.
        /// </summary>
        public static void ResetBeasiswaData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    IF OBJECT_ID('dbo.Beasiswa_backup') IS NOT NULL
                    BEGIN
                        DELETE FROM dbo.Beasiswa;
                        SET IDENTITY_INSERT dbo.Beasiswa ON;
                        INSERT INTO dbo.Beasiswa (id_beasiswa, nama_beasiswa, id_jenjang, id_kategori, tgl_buka, tgl_tutup, link_beasiswa, deskripsi, dibuat)
                        SELECT id_beasiswa, nama_beasiswa, id_jenjang, id_kategori, tgl_buka, tgl_tutup, link_beasiswa, deskripsi, dibuat FROM dbo.Beasiswa_backup;
                        SET IDENTITY_INSERT dbo.Beasiswa OFF;
                    END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Mengambil total beasiswa menggunakan output parameter pada sp_CountBeasiswa.
        /// </summary>
        public static int GetTotalBeasiswa()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CountBeasiswa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return outputParam.Value != DBNull.Value ? Convert.ToInt32(outputParam.Value) : 0;
                }
            }
        }

        /// <summary>
        /// Mengambil semua record dari tabel Beasiswa.
        /// </summary>
        public static DataTable GetAllBeasiswa()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Beasiswa";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Mengambil daftar jenjang (id_jenjang, nama_jenjang).
        /// </summary>
        public static DataTable GetJenjangList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_jenjang, nama_jenjang FROM Jenjang";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Mengambil daftar kategori (id_kategori, nama_kategori).
        /// </summary>
        public static DataTable GetKategoriList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_kategori, nama_kategori FROM Kategori";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Mengambil record beasiswa berdasarkan ID.
        /// </summary>
        public static DataTable GetBeasiswaById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Beasiswa WHERE id_beasiswa=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Menambahkan beasiswa baru dengan logging ke LogAktivitas menggunakan transaksi.
        /// </summary>
        public static void InsertBeasiswa(string nama, int idJenjang, int idKategori, DateTime tglBuka, DateTime tglTutup, string link, string deskripsi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_InsertBeasiswa", conn, trans))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@nama_beasiswa", nama);
                            cmd.Parameters.AddWithValue("@id_jenjang", idJenjang);
                            cmd.Parameters.AddWithValue("@id_kategori", idKategori);
                            cmd.Parameters.AddWithValue("@tgl_buka", tglBuka.Date);
                            cmd.Parameters.AddWithValue("@tgl_tutup", tglTutup.Date);
                            cmd.Parameters.AddWithValue("@link_beasiswa", link);
                            cmd.Parameters.AddWithValue("@deskripsi", deskripsi);

                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdLog = new SqlCommand(@"INSERT INTO LogAktivitas (aktivitas, waktu) VALUES (@aktivitas, GETDATE())", conn, trans))
                        {
                            cmdLog.Parameters.AddWithValue("@aktivitas", "INSERT Beasiswa : " + nama);
                            cmdLog.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch (SqlException ex)
                    {
                        trans.Rollback();
                        SimpanLogError("ROLLBACK INSERT: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Menambahkan beasiswa secara langsung (tanpa transaksi / LogAktivitas).
        /// </summary>
        public static void InsertBeasiswaSimple(string nama, int idJenjang, int idKategori, DateTime tglBuka, DateTime tglTutup, string link, string deskripsi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertBeasiswa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nama_beasiswa", nama);
                    cmd.Parameters.AddWithValue("@id_jenjang", idJenjang);
                    cmd.Parameters.AddWithValue("@id_kategori", idKategori);
                    cmd.Parameters.AddWithValue("@tgl_buka", tglBuka);
                    cmd.Parameters.AddWithValue("@tgl_tutup", tglTutup);
                    cmd.Parameters.AddWithValue("@link_beasiswa", link);
                    cmd.Parameters.AddWithValue("@deskripsi", deskripsi);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Mengupdate record beasiswa dengan memanggil sp_UpdateBeasiswa.
        /// </summary>
        public static int UpdateBeasiswa(int id, string nama, int idJenjang, int idKategori, DateTime tglBuka, DateTime tglTutup, string link, string deskripsi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateBeasiswa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_beasiswa", id);
                    cmd.Parameters.AddWithValue("@nama_beasiswa", nama);
                    cmd.Parameters.AddWithValue("@id_jenjang", idJenjang);
                    cmd.Parameters.AddWithValue("@id_kategori", idKategori);
                    cmd.Parameters.AddWithValue("@tgl_buka", tglBuka);
                    cmd.Parameters.AddWithValue("@tgl_tutup", tglTutup);
                    cmd.Parameters.AddWithValue("@link_beasiswa", link);
                    cmd.Parameters.AddWithValue("@deskripsi", deskripsi);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Mengupdate record beasiswa secara tidak aman (raw SQL query, demo SQL Injection).
        /// </summary>
        public static int UpdateBeasiswaUnsafe(string deskripsi, string namaBeasiswa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Beasiswa SET deskripsi='" + deskripsi + "' WHERE nama_beasiswa='" + namaBeasiswa + "'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Mencatat error ke tabel LogError.
        /// </summary>
        public static void SimpanLogError(string pesan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO LogError VALUES(GETDATE(), @pesan)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pesan", pesan);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Mencari ID Jenjang berdasarkan nama jenjang.
        /// </summary>
        public static int GetJenjangIdByName(string nama)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_jenjang FROM Jenjang WHERE nama_jenjang=@nama";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    return obj != null ? Convert.ToInt32(obj) : 0;
                }
            }
        }

        /// <summary>
        /// Mencari ID Kategori berdasarkan nama kategori.
        /// </summary>
        public static int GetKategoriIdByName(string nama)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_kategori FROM Kategori WHERE nama_kategori=@nama";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    return obj != null ? Convert.ToInt32(obj) : 0;
                }
            }
        }

        /// <summary>
        /// Mengambil kolom nama_jenjang saja dari tabel Jenjang.
        /// </summary>
        public static DataTable GetJenjangNames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT nama_jenjang FROM Jenjang";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Mengambil kolom nama_kategori saja dari tabel Kategori.
        /// </summary>
        public static DataTable GetKategoriNames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT nama_kategori FROM Kategori";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Mendapatkan data report dengan memanggil sp_Report.
        /// </summary>
        public static DataTable GetReport(string jenjang, string kategori, int bulan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Report", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inJenjang", SqlDbType.VarChar, 50).Value = jenjang;
                    cmd.Parameters.Add("@inKategori", SqlDbType.VarChar, 50).Value = kategori;
                    cmd.Parameters.Add("@inTglMsuk", SqlDbType.Int).Value = bulan;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
