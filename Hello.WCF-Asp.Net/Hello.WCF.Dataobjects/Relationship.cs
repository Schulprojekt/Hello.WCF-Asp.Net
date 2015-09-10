using System;
using System.Runtime.Serialization;

namespace Hello.WCF.Dataobjects
{
    [DataContract]
    public class Relationship
    {
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            set;
        }

        [DataMember(Name = "friendsId")]
        public Guid FriendsId
        {
            get;
            set;
        }

        [DataMember(Name = "userId")]
        public Guid UserId
        {
            get;
            set;
        }
    }
}
