using System;
using Hello.WCF.Dataobjects;
using Hello.WCF.DataAccess;
using System.Data.SqlClient;

namespace Hello.WCF.BuisnessLogic
{
    public class UserManager
    {
        /// <summary>
        /// Erstellt einen Benutzer in der DB
        /// </summary>
        /// <param name="user">
        /// Benutzerobjekt
        /// </param>
        public static void CreateUser(User user)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {   
                // Erstellen einer GUID
                user.UserID = Guid.NewGuid();
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                UserDal userDal = new UserDal();
                //Aufruf der Benutzererstellenmethode
                userDal.CreateUser(user, transaction);
                //Transaktion speichern
                transaction.Commit();
            }
        }

        /// <summary>
        /// Holt die Benutzerdaten des befreundeten Benutzers
        /// </summary>
        /// <param name="friendsId">
        /// FreundesId des Benutzers
        /// </param>
        /// <returns>
        /// Gibt ein Benutzerobjekt zurück
        /// </returns>
        public static User GetUserByUserId(Guid? friendsId)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                UserDal userDal = new UserDal();
                //Aufruf der BenutzerLesenByUserIdmethode
                User user = userDal.GetUserByUserId(friendsId, transaction);
                //Zurückgeben der Benutzerliste
                return user;
            }
        }

        /// <summary>
        /// Holt den Benutzer aus der DB anhand des Kontonamensa
        /// </summary>
        /// <param name="accountName">
        /// Kontonamen des anzumeldenden Benutzer
        /// </param>
        /// <returns>
        /// Gibt ein Benutzerobjekt zurück
        /// </returns>
        public static User GetUserByAccountName(string accountName)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {   
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                UserDal userDal = new UserDal();
                //Aufruf der BenutzerLesenByKontonamenmethode
                User user = userDal.GetUserByAccountName(accountName, transaction);
                //Zurückgeben des Benutzers
                return user;
            }
        }

        /// <summary>
        /// Speichert die Änderungen des Benutzers in der DB
        /// </summary>
        /// <param name="user">
        /// geändertes Benutzerobjekt
        /// </param>
        /// <returns>
        /// Gibt das gespeicherte Userobjekt wieder
        /// </returns>
        public static User UpdateUser(User user)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                UserDal userDal = new UserDal();
                //Aufruf der Benutzerändernmethode
                User useredit = userDal.UpdateUser(user, transaction);
                //Transaktion speichern
                transaction.Commit();
                //Zurückgeben des geänderten Benutzers
                return useredit;
            }
        }

        /// <summary>
        /// Löscht den Benutzer in der Datenbank
        /// </summary>
        /// <param name="user">
        /// Das zulöschende Benutzerobject
        /// </param>
        public static void DeleteUser(User user)
        {
            using (SqlTransaction transaction = ConnectionManager.GetOpenConnection().BeginTransaction())
            {
                //Zugriffssicht auf díe Datenbank deklarieren und instanzieren
                UserDal userDal = new UserDal();
                //Aufruf der Benutzerlöschenmethode
                userDal.DeleteUser(user, transaction);
                //Transaktion speichern
                transaction.Commit();
            }
        }
    }
}
