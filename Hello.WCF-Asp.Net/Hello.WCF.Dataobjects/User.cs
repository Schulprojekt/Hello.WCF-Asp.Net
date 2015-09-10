using System;
using System.Runtime.Serialization;

namespace Hello.WCF.Dataobjects
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "userId")]
        public Guid UserID
        {
            set;
            get;
        }

        [DataMember(Name = "aliasName")]
        public string AliasName
        {
            get;
            set;
        }

        [DataMember(Name = "accountName")]
        public string AccountName
        {
            get;
            set;
        }

        [DataMember(Name = "accountState")]
        public string AccountState
        {
            get;
            set;
        }

        [DataMember(Name = "expierencePoints")]
        public int ExpierencePoints
        {
            get;
            set;
        }

        [DataMember(Name = "picture")]
        public byte[] Picture
        {
            get;
            set;
        }
    }
}
