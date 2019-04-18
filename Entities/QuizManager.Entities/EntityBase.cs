using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace QuizManager.Entities
{
    [Serializable]
    [XmlType]
    [DataContract]
    public class EntityBase
    {
        [DataMember]
        [XmlElement]
        public long Id { get; set; }

        [DataMember]
        [XmlElement]
        public string CreatedBy { get; set; }

        [DataMember]
        [XmlElement]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        [XmlElement]
        public string ModifiedBy { get; set; }

        [DataMember]
        [XmlElement]
        public DateTime ModifiedDate { get; set; }
    }
}

