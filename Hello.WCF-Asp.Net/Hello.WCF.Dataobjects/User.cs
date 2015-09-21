using System;
using System.Runtime.Serialization;

namespace Hello.WCF.Dataobjects
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "userId")]
        public Guid? userID
        {
            set;
            get;
        }

        [DataMember(Name = "aliasName")]
        public string aliasName
        {
            get;
            set;
        }

        [DataMember(Name = "accountName")]
        public string accountName
        {
            get;
            set;
        }

        [DataMember(Name = "accountState")]
        public string accountState
        {
            get;
            set;
        }

        [DataMember(Name = "expierencePoints")]
        public int? expierencePoints
        {
            get;
            set;
        }

        [DataMember(Name = "picture")]
        public byte[] picture
        {
            get;
            set;
        }
        [DataMember(Name ="password")]
        public byte[] password
        {
            get;
            set;
        }
    }
}
