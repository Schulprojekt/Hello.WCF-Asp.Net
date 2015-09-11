using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;

namespace Hello.WCF.DataAccess
{
    public class UserDal
    {
        public void CreateUser(User user, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserId(Guid friendsId, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public User GetUserByAccountName(string accountName, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
