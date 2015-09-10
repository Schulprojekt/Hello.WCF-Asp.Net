using System;
using System.Runtime.Serialization;

namespace Hello.WCF.Dataobjects
{
    [DataContract]
    public class Message
    {
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            set;
        }

        [DataMember(Name = "sender")]
        public Guid Sender
        {
            get;
            set;
        }

        [DataMember(Name = "receiver")]
        public Guid Receiver
        {
            get;
            set;
        }

        [DataMember(Name = "message")]
        public string Messages
        {
            get;
            set;
        }

        [DataMember(Name = "attchment")]
        public byte[] Attchment
        {
            get;
            set;
        }

        [DataMember(Name = "timestamp")]
        public DateTime TimeStamp
        {
            get;
            set;
        }
    }
}
