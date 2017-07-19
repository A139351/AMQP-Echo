using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MessagePassThrough.Contracts
{
    [DataContract(Name = "IAMSAPDetails", Namespace = "urn:agl.com.au:azure:servicebus:common")]
    [XmlRoot(ElementName = "IAMSAPDetails", Namespace = "urn:agl.com.au:azure:servicebus:common")]
    public class InputMessage
    {
        [DataMember]
        [XmlElement(Namespace = "")]
        public string NameId { get; set; }
        [DataMember]
        [XmlElement(Namespace = "", ElementName = "Autho0Id")]
        public string Auth0Id { get; set; }
        [DataMember]
        [XmlElement(Namespace = "")]
        public string TransactionId { get; set; }
        [DataMember]
        [XmlElement(Namespace = "")]
        public string Date { get; set; }
        [DataMember]
        [XmlElement(Namespace = "")]
        public string Time { get; set; }
    }
}