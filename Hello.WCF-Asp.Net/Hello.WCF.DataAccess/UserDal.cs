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
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = user.UserID;
                sqlcmd.Parameters.Add("@Password", SqlDbType.Binary, user.Password.Length).Value = user.Password;
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountName;

                //Ausführen des SQLkommandos
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        /// Holt die Benutzer anhand der UserID aus der DB
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
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = friendsId;

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
                        user.UserID = dr["UserId"] as Guid?;
                        user.AliasName = dr["AliasName"] as string;
                        user.AccountName = dr["AccountName"] as string;
                        user.AccountState = dr["AccountState"] as string;
                        user.Picture = dr["Picture"] as byte[];
                        user.Password = dr["Password"] as byte[];
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
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, accountName.Length).Value = accountName;

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
                        user.UserID = dr["UserId"] as Guid?;
                        user.AliasName = dr["AliasName"] as string;
                        user.AccountName = dr["AccountName"] as string;
                        user.AccountState = dr["AccountState"] as string;
                        user.Picture = dr["Picture"] as byte[];
                        user.Password = dr["Password"] as byte[];
                        user.ExpierencePoints = dr["ExpierencePoints"] as int?;
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
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = user.UserID;
                sqlcmd.Parameters.Add("@Password", SqlDbType.Binary, user.Password.Length).Value = user.Password;
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountName;
                sqlcmd.Parameters.Add("@AliasName", SqlDbType.NVarChar, user.AliasName.Length).Value = user.AliasName;
                sqlcmd.Parameters.Add("@AccountState", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountState;
                sqlcmd.Parameters.Add("@Picture", SqlDbType.Binary, user.Picture.Length).Value = user.Picture;
                sqlcmd.Parameters.Add("@ExpierencePionts", SqlDbType.Int).Value = user.ExpierencePoints;

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
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountName;

                //Ausführen des SQLkommandos
                sqlcmd.ExecuteScalar();
            }
        }
    }
}
