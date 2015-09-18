using System.Data.SqlClient;

namespace Hello.WCF.BuisnessLogic
{
    public static class ConnectionManager
    {
        // Connectionobject zum Sql-Server
        private static SqlConnection conn = new SqlConnection();
        
        /// <summary>
        /// Öffnet die Connection zum Sql-Server
        /// </summary>
        public static void ConnectionOpen()
        {    // Setzen des Connectionstrings
            string connectionString = @"Server=Hello-Server;Database=Hello;Integrated Security=True;";
            // Zuweisung des Connstring zur SqlConnection Objekt
            conn = new SqlConnection(connectionString);
            //Öffnen der Connection
            conn.Open();
        }

        /// <summary>
        /// Schließt die Verbindung zum Sql-Server
        /// </summary>
        public static void ConnectionClose()
        {
            conn.Close();
        }

        /// <summary>
        /// Öffnet die Verbindung zum SQL-Server
        /// </summary>
        /// <returns>
        /// Gibt die Sql-Verbindung zurück
        /// </returns>
        public static SqlConnection GetOpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken)
                ConnectionOpen();

            return conn;
        }
    }
}
