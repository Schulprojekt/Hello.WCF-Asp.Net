using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello.WCF.Dataobjects;

namespace Hello.WCF.DataAccess
{
    public class RelationshipDal
    {
        public void CreateRelationship(Relationship relationship, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public static List<Relationship> GetRelationship(Guid userId, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteRelation(Relationship relationship, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
