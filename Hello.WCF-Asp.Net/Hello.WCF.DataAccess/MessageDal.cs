﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;

namespace Hello.WCF.DataAccess
{
    public class MessageDal
    {
        public List<Message> ReadMessage(Guid userId, SqlTransaction transaction)
        {
            return null;
        }

        public void CreateMessage(Message message, SqlTransaction transaction)
        {

        }

        public void MessageReaded(int messageId, SqlTransaction transaction)
        {

        }
    }
}
