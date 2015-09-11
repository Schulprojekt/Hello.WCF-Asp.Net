using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Hello.WCF.Dataobjects;

namespace Hello.WCF
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IMessengerService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract(Namespace="")]
    public interface IMessengerService
    {
        #region CreateMethods
        [OperationContract]
        [WebInvoke(
             Method = "Post",
             UriTemplate = "CreateUser",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json)]
        void CreateUser(User user);

        [OperationContract]
        [WebInvoke(
            Method = "Post",
            UriTemplate = "CreateMessage",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void CreateMessage(Message message);

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
        [OperationContract]
        [WebGet(
            UriTemplate = "GetRelationship/{userId}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        IList<User> GetRelationship(string userId);

        [OperationContract]
        [WebGet(
            UriTemplate = "GetMessages/{userId}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        IList<Message> GetMessages(string userId);

        [OperationContract]
        [WebGet(
            UriTemplate = "GetUserByAccountName/{AccountName}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        User GetUserByAccountName(string AccountName);
        #endregion

        #region UpdateMethods
        [OperationContract]
        [WebInvoke(
           Method = "Put",
           UriTemplate = "UpdateUser",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        User UpdateUser(User user);
        #endregion

        #region DeleteMethods
        [OperationContract]
        [WebInvoke(
           Method = "Delete",
           UriTemplate = "DeleteUser",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        void DeleteUser(User user);

        [OperationContract]
        [WebInvoke(
           Method = "Delete",
           UriTemplate = "DeleteRelationship",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        void DeleteRelationship(Relationship relationship);
        #endregion
    }
}
