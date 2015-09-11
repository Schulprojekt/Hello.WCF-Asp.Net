using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Hello.WCF.Dataobjects;

namespace Hello.WCF.DataAccess
{
    public class RelationshipDal
    {
        private const string createRelationshipMethod = "usp_Relationship_Create";
        private const string deleteRelationshipMethod = "usp_Relationship_Delete";
        private const string readRelationshipMethod = "usp_Relationship_Read_AllFriends";

        public byte[] CreateRelationship(Relationship relationship, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(createRelationshipMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = relationship.UserId;
                sqlcmd.Parameters.Add("@FriendId", SqlDbType.UniqueIdentifier).Value = relationship.FriendsId;
                byte[] result = (byte[])sqlcmd.ExecuteScalar();
                return result;
            }
        }

        public static List<Relationship> GetRelationship(Guid userId, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(readRelationshipMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                using (SqlDataAdapter dataApdater = new SqlDataAdapter(sqlcmd))
                {
                    DataTable friendsTable = new DataTable();
                    dataApdater.Fill(friendsTable);
                    List<Relationship> friendsList = new List<Relationship>();

                    foreach (DataRow dr in friendsTable.Rows)
                    {
                        Relationship friend = new Relationship();
                        friend.Id = dr["Id"] as int?;
                        friend.UserId = dr["UserId"] as Guid?;
                        friend.FriendsId = dr["FriendsId"] as Guid?;

                        friendsList.Add(friend);
                    }

                    return friendsList;
                }
            }
        }

        public void DeleteRelation(Relationship relationship, SqlTransaction transaction)
        {
            using (SqlCommand sqlcmd = new SqlCommand(deleteRelationshipMethod, transaction.Connection, transaction))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = relationship.UserId;
                sqlcmd.Parameters.Add("@FriendId", SqlDbType.UniqueIdentifier).Value = relationship.FriendsId;

                sqlcmd.ExecuteScalar();
            }
        }
    }
}
