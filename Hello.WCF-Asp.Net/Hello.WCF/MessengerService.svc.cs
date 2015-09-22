using System;
using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using Hello.WCF.BuisnessLogic;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

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
        public void CreateMessage(String message)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Message));
            ASCIIEncoding ascciEndcoding = new ASCIIEncoding();
            MemoryStream ms = new MemoryStream(ascciEndcoding.GetBytes(message));
            Message messageToCreate = (Message)json.ReadObject(ms);
            ms.Close();
            MessageManager.CreateMessage(messageToCreate);
        }

        /// <summary>
        /// Legt die Freunschaftsbeziehung in der Datenbank zwischen 2 Benutzern an 
        /// </summary>
        /// <param name="relationship">
        /// Das Freunschaftsbeziehungsobjekt zur Übergabe an die Datenbank
        /// </param>
        public void CreateRelationship(String relationship)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Relationship));
            ASCIIEncoding ascciEndcoding = new ASCIIEncoding();
            MemoryStream ms = new MemoryStream(ascciEndcoding.GetBytes(relationship));
            Relationship relationshipToCreate = (Relationship)json.ReadObject(ms);
            ms.Close();
            RelationshipManager.CreateRelationship(relationshipToCreate);
        }

        /// <summary>
        /// Legt einen Benutzer in der Datenbank an
        /// </summary>
        /// <param name="user">
        /// Das User-Objekt zur Übergabe an die Datenbank
        /// </param>
        public void CreateUser(String user)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(User));
            ASCIIEncoding ascciEndcoding = new ASCIIEncoding();
            MemoryStream ms = new MemoryStream(ascciEndcoding.GetBytes(user));
            User userToCreate = (User)json.ReadObject(ms);
            ms.Close();
            UserManager.CreateUser(userToCreate);
        }
        #endregion

        #region ReadMethods
        /// <summary>
        /// Gibt alle Freundschaftsbeziehungen des angelmeldeten Benutzers von der Datenbank wieder
        /// </summary>
        /// <param name="userId">
        /// Die id des angemeldten Benutzers
        /// </param>
        /// <returns>
        /// Gibt eine Freundesliste wieder vom Typ Benutzer
        /// </returns>
        public String GetRelationship(string userId)
        {
            List<Relationship> relationshipList = RelationshipManager.GetRelationships(new Guid(userId));
            List<User> friends = new List<User>();
            foreach (Relationship friendId in relationshipList)
            {
                User friend = UserManager.GetUserByUserId(friendId.friendsId);
                friends.Add(friend);
            }

            return JsonConvert.SerializeObject(friends);
        }

        /// <summary>
        /// Holt die Nachrichten von der Datenbank für den angemeldten Benutzer
        /// </summary>
        /// <param name="userId">
        /// Die id des angemeldeten Benutzers
        /// </param>
        /// <returns>
        /// Eine Liste von Nachrichten
        /// </returns>
        public string GetMessages(string userId)
        {
            List<Message> messageList = MessageManager.ReadMessage(new Guid(userId));
            foreach (Message msg in messageList)
            {
                MessageManager.MessageReaded(msg.id);
            }
            return JsonConvert.SerializeObject(messageList);
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
        public String GetUserByAccountName(string accountName)
        {
            User user = UserManager.GetUserByAccountName(accountName);
           return JsonConvert.SerializeObject(user);
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
        public String UpdateUser(string user)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(User));
            ASCIIEncoding ascciEndcoding = new ASCIIEncoding();
            MemoryStream ms = new MemoryStream(ascciEndcoding.GetBytes(user));
            User useredit = (User)json.ReadObject(ms);
            ms.Close();
            User usertoedit = UserManager.UpdateUser(useredit);
            return JsonConvert.SerializeObject(usertoedit);
        }
        #endregion

        #region DeleteMethods
        /// <summary>
        /// Löscht die Freundschaftsbeziehung zwischen 2 Benutzern
        /// </summary>
        /// <param name="relationship">
        /// Freunschaftsbeziehungsobjekt zwischen den 2 Benutzern
        /// </param>
        public void DeleteRelationship(String relationship)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Relationship));
            ASCIIEncoding ascciEndcoding = new ASCIIEncoding();
            MemoryStream ms = new MemoryStream(ascciEndcoding.GetBytes(relationship));
            Relationship relationshipToDelete = (Relationship)json.ReadObject(ms);
            ms.Close();
            RelationshipManager.DeleteRelationship(relationshipToDelete);
        }

        /// <summary>
        /// Löscht den angemeldeten Benutzer
        /// </summary>
        /// <param name="user">
        /// Benutzerobjekt des angemeldeten Benutzers
        /// </param>
        public void DeleteUser(string user)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(User));
            ASCIIEncoding ascciEndcoding = new ASCIIEncoding();
            MemoryStream ms = new MemoryStream(ascciEndcoding.GetBytes(user));
            User userToDelete = (User)json.ReadObject(ms);
            ms.Close();
            UserManager.DeleteUser(userToDelete);
        }
        #endregion
    }
}