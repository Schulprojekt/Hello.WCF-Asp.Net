using System;
using System.Data;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;

namespace Hello.WCF.DataAccess
{
    public class UserDal
    {
        //Datenbank Gespeicherte Prozedur
        private const string createUserMethod = "usp_User_Create";
        private const string readUserByIdMethod = "usp_User_Read_ByUserId";
        private const string readUserByAccountNameMethod = "usp_User_Read_ByAccountName";
        private const string updateUserMethod = "usp_User_Update";
        private const string deleteUserMethod = "usp_User_Delete";


        /// <summary>
        /// Erstellt den Benutzer in der DB
        /// </summary>
        /// <param name="user">
        /// Der zuspeichernde Benutzer
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt in Byte wieder ob Benutzer in DB erfolgreich gespeichert wurde
        /// </returns>
        public byte[] CreateUser(User user, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(createUserMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = user.userID;
                sqlcmd.Parameters.Add("@password", SqlDbType.Binary, user.password.Length).Value = user.password;
                sqlcmd.Parameters.Add("@accountName", SqlDbType.NVarChar, user.accountName.Length).Value = user.accountName;

                //Ausführen des SQLkommandos
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        /// Holt die Benutzer anhand der userID aus der DB
        /// </summary>
        /// <param name="friendsId">
        /// Die FriendId des befreundeten Benutzers
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Einen Benutzer mit allen Benutzerinfos
        /// </returns>
        public User GetUserByUserId(Guid? friendsId, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(readUserByIdMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = friendsId;

                // Ausführen des SQLkommandos und Speichern des Ergebnis in den Dataadapter
                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    // Dekalarieren der Datentabelle
                    DataTable userTable = new DataTable();

                    // Füllen der Datentabelle mit den Werten aus dem Dataadapter
                    dataApdater.Fill(userTable);

                    // Deklararieren des Benutzers
                    User user = new User();

                    // Durchgehen der Datentabellenreihen
                    foreach (DataRow dr in userTable.Rows)
                    { 
                        // Bauen des Benutzerobjekts
                        user.userID = dr["userId"] as Guid?;
                        user.aliasName = dr["aliasName"] as string;
                        user.accountName = dr["accountName"] as string;
                        user.accountState = dr["accountState"] as string;
                        user.picture = dr["picture"] as byte[];
                        user.password = dr["password"] as byte[];
                    }

                    // Rückgabe des Benutzerobjekts
                    return user;
                }
            }
        }

        /// <summary>
        /// Holt die Benutzer anhand des Benutzernamens aus der DB
        /// </summary>
        /// <param name="accountName">
        /// Der Benutzername des anzumeldenden Benutzers
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt den angemeldeten Benutzer wieder
        /// </returns>
        public User GetUserByAccountName(string accountName, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(readUserByAccountNameMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@accountName", SqlDbType.NVarChar, accountName.Length).Value = accountName;

                // Ausführen des SQLkommandos und Speichern des Ergebnis in den Dataadapter
                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    // Dekalarieren der Datentabelle
                    DataTable userTable = new DataTable();

                    // Füllen der Datentabelle mit den Werten aus dem Dataadapter
                    dataApdater.Fill(userTable);

                    // Deklararieren des Benutzers
                    User user = new User();

                    // Durchgehen der Datentabellenreihen
                    foreach (DataRow dr in userTable.Rows)
                    {
                        // Bauen des Benutzerobjekts
                        user.userID = dr["userId"] as Guid?;
                        user.aliasName = dr["aliasName"] as string;
                        user.accountName = dr["accountName"] as string;
                        user.accountState = dr["accountState"] as string;
                        user.picture = dr["picture"] as byte[];
                        user.password = dr["password"] as byte[];
                        user.expierencePoints = dr["expierencePoints"] as int?;
                    }

                    // Rückgabe des Benutzerobjekts
                    return user;
                }
            }
        }

        /// <summary>
        /// Speichert die Änderungen an dem User in der DB
        /// </summary>
        /// <param name="user">
        /// Der zuändernde Benutzer
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt den geänderten Benutzer aus der DB wieder
        /// </returns>
        public User UpdateUser(User user, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(createUserMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = user.userID;
                sqlcmd.Parameters.Add("@password", SqlDbType.Binary, user.password.Length).Value = user.password;
                sqlcmd.Parameters.Add("@accountName", SqlDbType.NVarChar, user.accountName.Length).Value = user.accountName;
                sqlcmd.Parameters.Add("@aliasName", SqlDbType.NVarChar, user.aliasName.Length).Value = user.aliasName;
                sqlcmd.Parameters.Add("@accountState", SqlDbType.NVarChar, user.accountName.Length).Value = user.accountState;
                sqlcmd.Parameters.Add("@picture", SqlDbType.Binary, user.picture.Length).Value = user.picture;
                sqlcmd.Parameters.Add("@ExpierencePionts", SqlDbType.Int).Value = user.expierencePoints;

                //Ausführen des SQLkommandos
                sqlcmd.ExecuteScalar();

                // Rückgabe des geänderten Benutzers
                return user;
            }
        }

        /// <summary>
        /// Löscht den Benutzer aus der DB
        /// </summary>
        /// <param name="user">
        /// Der zulöschende Benutzer
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        public void DeleteUser(User user, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(deleteUserMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@accountName", SqlDbType.NVarChar, user.accountName.Length).Value = user.accountName;

                //Ausführen des SQLkommandos
                sqlcmd.ExecuteScalar();
            }
        }
    }
}
