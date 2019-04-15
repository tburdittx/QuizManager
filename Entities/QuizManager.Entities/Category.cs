using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizManager.Entities
{
    [Serializable]
    [XmlType]
    [DataContract]
    public class Category:EntityBase
    {
        [DataMember]
        [XmlElement]
        public string Name { get; set; }

        [DataMember]
        [XmlElement]
        public string Description { get; set; }
    }
}
