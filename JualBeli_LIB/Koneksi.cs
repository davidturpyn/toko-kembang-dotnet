using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JualBeli_LIB
{
    public class Koneksi
    {
        private string nameServer;
        private string nameDatabase;
        private string username;
        private string password;
        private MySqlConnection koneksiDB;

        #region Constructor
        public Koneksi()
        {
            koneksiDB = new MySqlConnection();
            koneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;
            string hasilConnect = Connect();
        }

        public Koneksi(string nServer, string nDatabase, string user, string pass)
        {
            nameServer = nServer;
            nameDatabase = nDatabase;
            username = user;
            password = pass;

            string strCon = "server=" + nameServer + "; database=" + nameDatabase + "; uid=" + username + "; pwd=" + password + ";";

            koneksiDB = new MySqlConnection();
            koneksiDB.ConnectionString = strCon;

            if (Connect() == "sukses")
            {
                UpdateAppConfig(strCon);
            }
        }
        #endregion

        public string NameServer
        {
            get { return nameDatabase; }
            set { nameDatabase = value; }
        }

        public string NameDatabase
        {
            get { return nameDatabase; }
            set { nameDatabase = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public MySqlConnection KoneksiDB
        {
            get { return koneksiDB; }
            private set { koneksiDB = value; }
        }

        #region Methode

        public string Connect()
        {
            try
            {
                if (KoneksiDB.State == System.Data.ConnectionState.Open)
                {
                    koneksiDB.Close();
                }

                koneksiDB.Open();
                return "sukses";
            }
            catch (Exception ex)
            {
                return "Koneksi gagal. Pesan kesalahan : " + ex;
            }
        }

        public void UpdateAppConfig(string connectionString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString = connectionString;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static MySqlDataReader jalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            MySqlDataReader hasil = c.ExecuteReader();

            return hasil;
        }

        public static void DML(string sql)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            c.ExecuteNonQuery();
        }

        public static string GetNamaServer()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;
            return con.DataSource;
        }
        public static string GetNamaDataBase()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["KonfigurasiKoneksi"].ConnectionString;
            return con.Database;
        }
        #endregion
    }
}
