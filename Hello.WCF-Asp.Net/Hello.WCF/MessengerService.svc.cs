using System;
using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using Hello.WCF.BuisnessLogic;

namespace Hello.WCF
{
    // HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts MessengerService.svc oder MessengerService.svc.cs im Projektmappen-Explorer aus, und starten Sie das Debuggen.
    public class MessengerService : IMessengerService
    {
        #region CreateMethods
        /// <summary>
        /// Legt und Sendet die Nachrichten an die Datenbank an
        /// </summary>
        /// <param name="message">
        /// Das Nachrichten-Objekt zur Übergabe an die Datenbank
        /// </param>
        public void CreateMessage(Message message)
        {
            MessageManager.CreateMessage(message);
        }

        /// <summary>
        /// Legt die Freunschaftsbeziehung in der Datenbank zwischen 2 Benutzern an 
        /// </summary>
        /// <param name="relationship">
        /// Das Freunschaftsbeziehungsobjekt zur Übergabe an die Datenbank
        /// </param>
        public void CreateRelationship(Relationship relationship)
        {
            RelationshipManager.CreateRelationship(relationship);
        }

        /// <summary>
        /// Legt einen Benutzer in der Datenbank an
        /// </summary>
        /// <param name="user">
        /// Das User-Objekt zur Übergabe an die Datenbank
        /// </param>
        public void CreateUser(User user)
        {
            UserManager.CreateUser(user);
        }
        #endregion

        #region ReadMethods
        /// <summary>
        /// Gibt alle Freundschaftsbeziehungen des angelmeldeten Benutzers von der Datenbank wieder
        /// </summary>
        /// <param name="userId">
        /// Die Id des angemeldten Benutzers
        /// </param>
        /// <returns>
        /// Gibt eine Freundesliste wieder vom Typ Benutzer
        /// </returns>
        public IList<User> GetRelationship(string userId)
        {
            List<Relationship> relationshipList = RelationshipManager.GetRelationships(new Guid(userId));
            List<User> friends = new List<User>();
            foreach (Relationship friendId in relationshipList)
            {
                User friend = UserManager.GetUserByUserId(friendId.FriendsId);
                friends.Add(friend);
            }

            return friends;
        }

        /// <summary>
        /// Holt die Nachrichten von der Datenbank für den angemeldten Benutzer
        /// </summary>
        /// <param name="userId">
        /// Die Id des angemeldeten Benutzers
        /// </param>
        /// <returns>
        /// Eine Liste von Nachrichten
        /// </returns>
        public IList<Message> GetMessages(string userId)
        {
            List<Message> messageList = MessageManager.ReadMessage(new Guid(userId));
            foreach (Message msg in messageList)
            {
                MessageManager.MessageReaded(msg.Id);
            }
            return messageList;
        }

        /// <summary>
        /// Holt die Userdaten zum angebenen Accountnamen aus der Datenbank
        /// </summary>
        /// <param name="AccountName">
        /// Benutzername für die Suche der Benutzerdaten in der Datenbank
        /// </param>
        /// <returns>
        /// Ein Benutzerobjekt vom Typ User
        /// </returns>
        public User GetUserByAccountName(string accountName)
        {
           User user = UserManager.GetUserByAccountName(accountName);
           return user;
        }
        #endregion

        #region UpdateMethod
        /// <summary>
        /// Ändern des angemeldten Benutzers
        /// </summary>
        /// <param name="user">
        /// Benutzerobjekt um den Benutzer in der Datenbank zu zuändern
        /// </param>
        /// <returns>
        /// Gibt den geänderten Daten zurück
        /// </returns>
        public User UpdateUser(User user)
        {
            User useredit = UserManager.UpdateUser(user);
            return useredit;
        }
        #endregion

        #region DeleteMethods
        /// <summary>
        /// Löscht die Freundschaftsbeziehung zwischen 2 Benutzern
        /// </summary>
        /// <param name="relationship">
        /// Freunschaftsbeziehungsobjekt zwischen den 2 Benutzern
        /// </param>
        public void DeleteRelationship(Relationship relationship)
        {
            RelationshipManager.DeleteRelationship(relationship);
        }

        /// <summary>
        /// Löscht den angemeldeten Benutzer
        /// </summary>
        /// <param name="user">
        /// Benutzerobjekt des angemeldeten Benutzers
        /// </param>
        public void DeleteUser(User user)
        {
            UserManager.DeleteUser(user);
        }
        #endregion
    }
}