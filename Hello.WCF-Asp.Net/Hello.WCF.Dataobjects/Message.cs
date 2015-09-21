using System;
using System.Runtime.Serialization;

namespace Hello.WCF.Dataobjects
{
    [DataContract]
    public class Message
    {
        [DataMember(Name = "id")]
        public int? id
        {
            get;
            set;
        }

        [DataMember(Name = "sender")]
        public Guid? sender
        {
            get;
            set;
        }

        [DataMember(Name = "receiver")]
        public Guid? receiver
        {
            get;
            set;
        }

        [DataMember(Name = "message")]
        public string messages
        {
            get;
            set;
        }

        [DataMember(Name = "attchment")]
        public byte[] attchment
        {
            get;
            set;
        }

        [DataMember(Name = "timestamp")]
        public DateTime? timeStamp
        {
            get;
            set;
        }
    }
}
