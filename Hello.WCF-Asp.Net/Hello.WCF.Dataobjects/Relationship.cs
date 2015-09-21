using System;
using System.Runtime.Serialization;

namespace Hello.WCF.Dataobjects
{
    [DataContract]
    public class Relationship
    {
        [DataMember(Name = "id")]
        public int? id
        {
            get;
            set;
        }

        [DataMember(Name = "friendsId")]
        public Guid? friendsId
        {
            get;
            set;
        }

        [DataMember(Name = "userId")]
        public Guid? userId
        {
            get;
            set;
        }
    }
}
