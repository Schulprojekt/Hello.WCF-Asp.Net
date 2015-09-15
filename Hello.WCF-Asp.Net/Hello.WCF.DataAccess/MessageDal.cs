﻿using System;
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
        /// <returns></returns>
        public byte[] CreateMessage(Message message, SqlTransaction transaction)
        {
            //Erstellen und Instanzieren des SQLkommandos
            using (SqlCommand sqlcmd = new SqlCommand(createMessageMethod, transaction.Connection, transaction))
            {
                //Sqlkommandotyp auf Gespeicherte Prozedur setzen
                sqlcmd.CommandType = CommandType.StoredProcedure;
                
                //SQL-Parameter zum SQLkommando hinzufügen
                sqlcmd.Parameters.Add("@Sender", SqlDbType.UniqueIdentifier).Value = message.Sender;
                sqlcmd.Parameters.Add("@Receiver", SqlDbType.UniqueIdentifier).Value = message.Receiver;
                sqlcmd.Parameters.Add("@Attchment", SqlDbType.VarBinary, message.Attchment.Length).Value = message.Attchment;
                sqlcmd.Parameters.Add("@Message", SqlDbType.NVarChar, message.Messages.Length).Value = message.Messages;

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
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                // Ausführen des SQLkommandos und Speichern der 
                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    DataTable MessagesTable = new DataTable();
                    dataApdater.Fill(MessagesTable);
                    List<Message> messageList = new List<Message>();

                    foreach (DataRow dr in MessagesTable.Rows)
                    {
                        Message message = new Message();
                        message.Id = dr["Id"] as int?;
                        message.Sender = dr["Sender"] as Guid?;
                        message.Receiver = dr["Receiver"] as Guid?;
                        message.Messages = dr["Message"] as string;
                        message.Attchment = dr["Attchment"] as byte[];
                        message.TimeStamp = dr["Timestamp"] as DateTime?;

                        messageList.Add(message);
                    }

                    return messageList;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public byte[] MessageReaded(int? messageId, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(messageReadedMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = messageId;

                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }
    }
}
