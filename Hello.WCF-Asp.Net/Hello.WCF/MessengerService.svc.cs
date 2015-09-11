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
        public void CreateMessage(Message message)
        {
            MessageManager.CreateMessage(message);
        }

        public void CreateRelationship(Relationship relationship)
        {
            RelationshipManager.CreateRelationship(relationship);
        }

        public void CreateUser(User user)
        {
            UserManager.CreateUser(user);
        }
        #endregion

        #region ReadMethods
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

        public IList<Message> GetMessages(string userId)
        {
            List<Message> messageList = MessageManager.ReadMessage(new Guid(userId));
            foreach (Message msg in messageList)
            {
                MessageManager.MessageReaded(msg.Id);
            }
            return messageList;
        }

        public User GetUserByAccountName(string accountName)
        {
           User user = UserManager.GetUserByAccountName(accountName);
           return user;
        }
        #endregion

        #region UpdateMethod
        public User UpdateUser(User user)
        {
            User useredit = UserManager.UpdateUser(user);
            return useredit;
        }
        #endregion

        #region DeleteMethods
        public void DeleteRelationship(Relationship relationship)
        {
            RelationshipManager.DeleteRelationship(relationship);
        }

        public void DeleteUser(User user)
        {
            UserManager.DeleteUser(user);
        }
        #endregion
    }
}