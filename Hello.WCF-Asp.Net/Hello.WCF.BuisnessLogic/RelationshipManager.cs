using System;
using System.Collections.Generic;
using Hello.WCF.Dataobjects;
using System.Data.SqlClient;
using Hello.WCF.DataAccess;

namespace Hello.WCF.BuisnessLogic
{
    public static class RelationshipManager
    {
        /// <summary>
        /// Speichert die Beziehung zwischen Benutzern in DB
        /// </summary>
        /// <param name="relationship">
        /// Beziehungsobjekt
        /// </param>
        public static void CreateRelationship(Relationship relationship)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                RelationshipDal relationDal = new RelationshipDal();
                //Aufruf der Beziehungserstellenmethode
                relationDal.CreateRelationship(relationship, transaction);
                //Transaktion speichern
                transaction.Commit();
            }
        }
        
        /// <summary>
        /// Holt alle Beziehungen aus der DB
        /// </summary>
        /// <param name="userId">
        /// Die id des angemeldeten Benutzers
        /// </param>
        /// <returns>
        /// Gibt eine Liste von Beziehung zwischen Benutzern und dem angenmeldeten Benuzter
        /// </returns>
        public static List<Relationship> GetRelationships(Guid userId)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                RelationshipDal relationDal = new RelationshipDal();
                //Aufruf der Beziehungslesenmethode
                List<Relationship> relationshipList = RelationshipDal.GetRelationship(userId, transaction);
                //Zurückgeben der Beziehungsliste
                return relationshipList;
            }
        }

        /// <summary>
        /// Löscht die Beziehung in DB
        /// </summary>
        /// <param name="relationship">
        /// Beziehungsobjekt
        /// </param>
        public static void DeleteRelationship(Relationship relationship)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {   
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                RelationshipDal relationDal = new RelationshipDal();
                //Aufruf der Beziehungslöschenmethode
                relationDal.DeleteRelation(relationship, transaction);
                //Transaktion speichern
                transaction.Commit();
            }
        }
    }
}
