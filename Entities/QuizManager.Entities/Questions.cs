using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizManager.Entities
{
    [Serializable]
    [XmlType]
    [DataContract]
    public class Questions:EntityBase
    {
        [DataMember]
        [XmlElement]
        public string Question { get; set; }

        [DataMember]
        [XmlElement]
        public string OptionA { get; set; }

        [DataMember]
        [XmlElement]
        public string OptionB { get; set; }

        [DataMember]
        [XmlElement]
        public string OptionC { get; set; }

        [DataMember]
        [XmlElement]
        public string OptionD { get; set; }

        [DataMember]
        [XmlElement]
        public string Answer { get; set; }

        [DataMember]
        [XmlElement]
        public string Explanation { get; set; }
    }
}

