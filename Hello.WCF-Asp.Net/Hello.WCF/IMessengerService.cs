using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Hello.WCF.Dataobjects;

namespace Hello.WCF
{
    /// <summary>
    /// Das Interface für die Dienste des Messengers
    /// </summary>
    [ServiceContract]//(Namespace="")]
    public interface IMessengerService
    {
        #region CreateMethods
        /// <summary>
        /// Legt einen Benutzer in der Datenbank an
        /// </summary>
        /// <param name="user">
        /// Das User-Objekt zur Übergabe an die Datenbank
        /// </param>
        [OperationContract]
        [WebInvoke(
             Method = "Post",
             UriTemplate = "CreateUser",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json)]
        void CreateUser(User user);

        /// <summary>
        /// Legt und Sendet die Nachrichten an die Datenbank an
        /// </summary>
        /// <param name="message">
        /// Das Nachrichten-Objekt zur Übergabe an die Datenbank
        /// </param>
        [OperationContract]
        [WebInvoke(
            Method = "Post",
            UriTemplate = "CreateMessage",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void CreateMessage(Message message);

        /// <summary>
        /// Legt die Freunschaftsbeziehung in der Datenbank zwischen 2 Benutzern an 
        /// </summary>
        /// <param name="relationship">
        /// Das Freunschaftsbeziehungsobjekt zur Übergabe an die Datenbank
        /// </param>
        [OperationContract]
        [WebInvoke(
            Method = "Post",
            UriTemplate = "CreateRelationship",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void CreateRelationship(Relationship relationship);
        #endregion

        #region ReadMethods
        /// <summary>
        /// Gibt alle Freundschaftsbeziehungen des angelmeldeten Benutzers von der Datenbank wieder
        /// </summary>
        /// <param name="userId">
        /// Die Id des angemeldten Benutzers
        /// </param>
        /// <returns>
        /// Gibt eine Freundesliste wieder vom Typ Benutzer
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "GetRelationship/{userId}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        IList<User> GetRelationship(string userId);

        /// <summary>
        /// Holt die Nachrichten von der Datenbank für den angemeldten Benutzer
        /// </summary>
        /// <param name="userId">
        /// Die Id des angemeldeten Benutzers
        /// </param>
        /// <returns>
        /// Eine Liste von Nachrichten
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "GetMessages/{userId}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        IList<Message> GetMessages(string userId);

        /// <summary>
        /// Holt die Userdaten zum angebenen Accountnamen aus der Datenbank
        /// </summary>
        /// <param name="AccountName">
        /// Benutzername für die Suche der Benutzerdaten in der Datenbank
        /// </param>
        /// <returns>
        /// Ein Benutzerobjekt vom Typ User
        /// </returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "GetUserByAccountName/{AccountName}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        User GetUserByAccountName(string AccountName);
        #endregion

        #region UpdateMethod
        /// <summary>
        /// Ändern des angemeldten Benutzers
        /// </summary>
        /// <param name="user">
        /// Benutzerobjekt um den Benutzer in der Datenbank zu zuändern
        /// </param>
        /// <returns>
        /// Gibt den geänderten Daten zurück
        /// </returns>
        [OperationContract]
        [WebInvoke(
           Method = "Post",
           UriTemplate = "UpdateUser",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        User UpdateUser(User user);
        #endregion

        #region DeleteMethods
        /// <summary>
        /// Löscht den angemeldeten Benutzer
        /// </summary>
        /// <param name="user">
        /// Benutzerobjekt des angemeldeten Benutzers
        /// </param>
        [OperationContract]
        [WebInvoke(
           Method = "Post",
           UriTemplate = "DeleteUser",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        void DeleteUser(User user);
        
        /// <summary>
        /// Löscht die Freundschaftsbeziehung zwischen 2 Benutzern
        /// </summary>
        /// <param name="relationship">
        /// Freunschaftsbeziehungsobjekt zwischen den 2 Benutzern
        /// </param>
        [OperationContract]
        [WebInvoke(
           Method = "Post",
           UriTemplate = "DeleteRelationship",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        void DeleteRelationship(Relationship relationship);
        #endregion
    }
}
