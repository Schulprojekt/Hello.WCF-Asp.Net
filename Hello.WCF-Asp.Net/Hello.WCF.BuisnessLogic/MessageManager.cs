using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using Hello.WCF.DataAccess;
using System.Data.SqlClient;
using System;

namespace Hello.WCF.BuisnessLogic
{
    public static class MessageManager
    {
        /// <summary>
        /// Schleust die zu erstellende Nachricht zur Dal durch mit einer Sqltransaction
        /// </summary>
        /// <param name="message">
        /// zu erstellende Nachricht
        /// </param>
        public static void CreateMessage(Message message)
        {
            // Öffnen der Sql-Server-Verbindung
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {   
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                MessageDal msgDal = new MessageDal();
                //Aufruf der Nachrichterstellenmethode
                msgDal.CreateMessage(message, transaction);
                //Transaktion speichern
                transaction.Commit();
            }
        }

        /// <summary>
        /// Holt die Nachrichten aus der Dal
        /// </summary>
        /// <param name="userId">
        /// Id des angemledeten Benutzers
        /// </param>
        /// <returns>
        /// Gibt eine Nachrichtenliste wieder
        /// </returns>
        public static List<Message> ReadMessage(Guid userId)
        {
            //Öffnen der Sql-Server-Verbindung
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {   
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                MessageDal msgDal = new MessageDal();
                //Aufruf der Nachrichtenlesenmethode
                List<Message> messageList = msgDal.ReadMessage(userId, transaction);
                
                //Zurückgeben der Nachrichtenliste
                return messageList;
            }
        }

        /// <summary>
        /// Setzt die Nachrichten auf gelesen
        /// </summary>
        /// <param name="messageId">
        /// Nachrichten-Id
        /// </param>
        public static void MessageReaded(int? messageId)
        {
            //Öffnen der Sql-Server-Verbindung
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                MessageDal msgDal = new MessageDal();
                //Aufruf der Nachrichtgelesenmethode
                msgDal.MessageReaded(messageId, transaction);
                //Transaktion speichern
                transaction.Commit();
            }
        }

        
    }
}
