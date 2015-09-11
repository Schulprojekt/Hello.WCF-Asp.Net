using System;
using Hello.WCF.Dataobjects;
using Hello.WCF.DataAccess;
using System.Data.SqlClient;

namespace Hello.WCF.BuisnessLogic
{
    public class UserManager
    {
        public static void CreateUser(User user)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                UserDal userDal = new UserDal();
                userDal.CreateUser(user, transaction);
                transaction.Commit();
            }
        }

        public static User GetUserByUserId(Guid friendsId)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                UserDal userDal = new UserDal();
                User user = userDal.GetUserByUserId(friendsId, transaction);
                return user;
            }
        }

        public static User GetUserByAccountName(string accountName)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                UserDal userDal = new UserDal();
                User user = userDal.GetUserByAccountName(accountName, transaction);
                return user;
            }
        }

        public static User UpdateUser(User user)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                UserDal userDal = new UserDal();
                User useredit = userDal.UpdateUser(user, transaction);
                transaction.Commit();
                return useredit;
            }
        }

        public static void DeleteUser(User user)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                UserDal userDal = new UserDal();
                userDal.DeleteUser(user, transaction);
                transaction.Commit();
            }
        }
    }
}
