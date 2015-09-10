﻿using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using Hello.WCF.DataAccess;
using System.Data.SqlClient;

namespace Hello.WCF.BuisnessLogic
{
    public static class MessageManager
    {
        public static void CreateMessage(Message message)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                MessageDal msgDal = new MessageDal();
                msgDal.CreateMessage(message);
                transaction.Commit();
            }
        }

        public static List<Message> ReadMessage()
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                MessageDal msgDal = new MessageDal();
                List<Message> messageList = msgDal.ReadMessage(transaction);

                return messageList;
            }
        }

        public static void MessageReaded(int messageId)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                MessageDal msgDal = new MessageDal();
                msgDal.MessageReaded(messageId);
                transaction.Commit();
            }
        }

        
    }
}
