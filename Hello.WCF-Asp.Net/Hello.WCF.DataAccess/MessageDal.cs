using System;
using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;
using System.Data;

namespace Hello.WCF.DataAccess
{
    public class MessageDal
    {
        //Datenbank Gespeicherte Prozedur
        private const string createMessageMethod = "usp_Message_Create";
        private const string readMessage = "usp_Message_Read";
        private const string messageReadedMethod = "usp_Message_Readed";

        /// <summary>
        /// Erstellt die Nachricht in der DB
        /// </summary>
        /// <param name="message">
        /// Das zuspeicherende Nachrichtenobjekt
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt in Byte wieder ob Nachrichten in DB erfolgreich gespeichert wurde
        /// </returns>
        public byte[] CreateMessage(Message message, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(createMessageMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;
                
                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@sender", SqlDbType.UniqueIdentifier).Value = message.sender;
                sqlcmd.Parameters.Add("@receiver", SqlDbType.UniqueIdentifier).Value = message.receiver;
                sqlcmd.Parameters.Add("@attchment", SqlDbType.VarBinary, message.attchment.Length).Value = message.attchment;
                sqlcmd.Parameters.Add("@Message", SqlDbType.NVarChar, message.messages.Length).Value = message.messages;

                //Ausführen des SQLkommandos
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        ///  Holt alle Nachrichten aus der DB
        /// </summary>
        /// <param name="userId">
        /// Alle Nachrichten des angemeldeten Benutzers
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt eine Liste von Nachrichten zurück
        /// </returns>
        public List<Message> ReadMessage(Guid userId, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(readMessage, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;

                // Ausführen des SQLkommandos und Speichern des Ergebnis in den Dataadapter
                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    // Dekalarieren der Datentabelle
                    DataTable MessagesTable = new DataTable();
                    
                    // Füllen der Datentabelle mit den Werten aus dem Dataadapter
                    dataApdater.Fill(MessagesTable);

                    //Deklararieren der Liste von Nachrichten
                    List<Message> messageList = new List<Message>();

                    // Durchgehen der Datentabellenreihen
                    foreach (DataRow dr in MessagesTable.Rows)
                    {
                        //Bauen eines Nachrichtenobjekts
                        Message message = new Message();
                        message.id = dr["id"] as int?;
                        message.sender = dr["sender"] as Guid?;
                        message.receiver = dr["receiver"] as Guid?;
                        message.messages = dr["Message"] as string;
                        message.attchment = dr["attchment"] as byte[];
                        message.timeStamp = dr["Timestamp"] as DateTime?;

                        // hinzufügen des Nachrichtenobjekts
                        messageList.Add(message);
                    }

                    //Rückgabe der Nachrichtenliste
                    return messageList;
                }
            }
        }

        /// <summary>
        /// Abgeholte Nachrichten auf gelesen in der DB setzen
        /// </summary>
        /// <param name="messageId">
        /// Nachrichtennummer
        /// </param>
        /// <param name="transaction">
        /// Sicherung der SQL-Interaktion
        /// </param>
        /// <returns>
        /// Gibt in Byte wieder ob Nachrichten gelesen in DB erfolgreich gespeichert wurde
        /// </returns>
        public byte[] MessageReaded(int? messageId, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(messageReadedMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = messageId;

                //Ausführen des SQLkommandos
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }
    }
}
