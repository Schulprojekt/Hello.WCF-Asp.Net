using System;
using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;
using Hello.WCF.DataAccess;

namespace Hello.WCF.BuisnessLogic
{
    public static class RelationshipManager
    {
        public static void CreateRelationship(Relationship relationship)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                RelationshipDal relationDal = new RelationshipDal();
                relationDal.CreateRelationship(relationship, transaction);
                transaction.Commit();
            }
        }

        public static List<Relationship> GetRelationships(Guid userId)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                RelationshipDal relationDal = new RelationshipDal();
                List<Relationship> relationshipList = RelationshipDal.GetRelationship(userId, transaction);
                return relationshipList;
            }
        }

        public static void DeleteRelationship(Relationship relationship)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                RelationshipDal relationDal = new RelationshipDal();
                relationDal.DeleteRelation(relationship, transaction);
                transaction.Commit();
            }
        }
    }
}
