using System;
using System.Data;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;

namespace Hello.WCF.DataAccess
{
    public class UserDal
    {
        private const string createUserMethod = "usp_User_Create";
        private const string readUserByIdMethod = "usp_User_Read_ByUserId";
        private const string readUserByAccountNameMethod = "usp_User_Read_ByAccountName";
        private const string updateUserMethod = "usp_User_Update";
        private const string deleteUserMethod = "usp_User_Delete";

        public byte[] CreateUser(User user, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(createUserMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = user.UserID;
                sqlcmd.Parameters.Add("@Password", SqlDbType.Binary, user.Password.Length).Value = user.Password;
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountName;
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }

        public User GetUserByUserId(Guid? friendsId, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(readUserByIdMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = friendsId;

                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    DataTable userTable = new DataTable();
                    dataApdater.Fill(userTable);
                    User user = new User();
                    foreach (DataRow dr in userTable.Rows)
                    { 
                        user.UserID = dr["UserId"] as Guid?;
                        user.AliasName = dr["AliasName"] as string;
                        user.AccountName = dr["AccountName"] as string;
                        user.AccountState = dr["AccountState"] as string;
                        user.Picture = dr["Picture"] as byte[];
                        user.Password = dr["Password"] as byte[];
                    }

                    return user;
                }
            }
        }

        public User GetUserByAccountName(string accountName, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(readUserByAccountNameMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, accountName.Length).Value = accountName;

                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    DataTable userTable = new DataTable();
                    dataApdater.Fill(userTable);
                    User user = new User();
                    foreach (DataRow dr in userTable.Rows)
                    {
                        user.UserID = dr["UserId"] as Guid?;
                        user.AliasName = dr["AliasName"] as string;
                        user.AccountName = dr["AccountName"] as string;
                        user.AccountState = dr["AccountState"] as string;
                        user.Picture = dr["Picture"] as byte[];
                        user.Password = dr["Password"] as byte[];
                        user.ExpierencePoints = dr["ExpierencePoints"] as int?;
                    }

                    return user;
                }
            }
        }

        public User UpdateUser(User user, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(createUserMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = user.UserID;
                sqlcmd.Parameters.Add("@Password", SqlDbType.Binary, user.Password.Length).Value = user.Password;
                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountName;
                sqlcmd.Parameters.Add("@AliasName", SqlDbType.NVarChar, user.AliasName.Length).Value = user.AliasName;
                sqlcmd.Parameters.Add("@AccountState", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountState;
                sqlcmd.Parameters.Add("@Picture", SqlDbType.Binary, user.Picture.Length).Value = user.Picture;
                sqlcmd.Parameters.Add("@ExpierencePionts", SqlDbType.Int).Value = user.ExpierencePoints;

                sqlcmd.ExecuteScalar();

                return user;
            }
        }

        public void DeleteUser(User user, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(deleteUserMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, user.AccountName.Length).Value = user.AccountName;

                sqlcmd.ExecuteScalar();
            }
        }
    }
}
