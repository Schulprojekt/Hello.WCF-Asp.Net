using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Hello.WCF.Dataobjects;

namespace Hello.WCF.DataAccess
{
    public class RelationshipDal
    {
        //Datenbank Gespeicherte Prozedur
        private const string createRelationshipMethod = "usp_Relationship_Create";
        private const string deleteRelationshipMethod = "usp_Relationship_Delete";
        private const string readRelationshipMethod = "usp_Relationship_Read_AllFriends";

        /// <summary>
        /// Erstellt die Freundschftasbeziehung zwischen 2 Benutzern
        /// </summary>
        /// <param name="relationship">
        /// Das zuspeichernde Beziehungsobjekt
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt in Byte wieder ob Freundschaft in DB erfolgreich gespeichert wurde
        /// </returns>
        public byte[] CreateRelationship(Relationship relationship, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(createRelationshipMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = relationship.userId;
                sqlcmd.Parameters.Add("@FriendId", SqlDbType.UniqueIdentifier).Value = relationship.friendsId;

                //Ausführen des SQLkommandos
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        /// Holt alle Freundesbeziehung aus der DB
        /// </summary>
        /// <param name="userId">
        /// Die userId des angemeldeten Benutzers
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt eine Liste von Freundesbeziehungen wieder
        /// </returns>
        public static List<Relationship> GetRelationship(Guid userId, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(readRelationshipMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;

                // Ausführen des SQLkommandos und Speichern des Ergebnis in den Dataadapter
                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    // Dekalarieren der Datentabelle
                    DataTable friendsTable = new DataTable();

                    // Füllen der Datentabelle mit den Werten aus dem Dataadapter
                    dataApdater.Fill(friendsTable);

                    //Deklararieren der Liste von Freundschaftsbeziehungen
                    List<Relationship> friendsList = new List<Relationship>();

                    // Durchgehen der Datentabellenreihen
                    foreach (DataRow dr in friendsTable.Rows)
                    {
                        //Bauen eines Beziehungsobjekts
                        Relationship friend = new Relationship();
                        friend.id = dr["id"] as int?;
                        friend.userId = dr["userId"] as Guid?;
                        friend.friendsId = dr["friendsId"] as Guid?;

                        // hinzufügen des Beziehungsobjekts
                        friendsList.Add(friend);
                    }

                    //Rückgabe der Freundesliste
                    return friendsList;
                }
            }
        }

        /// <summary>
        /// Löscht Freundschaftsbeziehung zwischen 2 Benutzern in der DB
        /// </summary>
        /// <param name="relationship">
        /// Das zulöschende Beziehungsobjekt
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        public void DeleteRelation(Relationship relationship, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(deleteRelationshipMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = relationship.userId;
                sqlcmd.Parameters.Add("@FriendId", SqlDbType.UniqueIdentifier).Value = relationship.friendsId;

                //Ausführen des SQLkommandos
                sqlcmd.ExecuteScalar();
            }
        }
    }
}
