using System.Data.SqlClient;

namespace Hello.WCF.BuisnessLogic
{
    public static class ConnectionManager
    {
        private static SqlConnection conn = new SqlConnection();

        public static void ConnectionOpen()
        {
            string connectionString = @"";
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public static void ConnectionClose()
        {
            conn.Close();
        }

        public static SqlConnection GetOpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken)
                ConnectionOpen();

            return conn;
        }
    }
}
