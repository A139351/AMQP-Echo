using System.Xml.Serialization;

namespace MessagePassThrough.Contracts
{
    [XmlRoot(ElementName = "IAMAcknowledgement", Namespace = "urn:agl.com.au:azure:servicebus:common")]
    public class OutputMessage
    {
        [XmlElement(Namespace = "")]
        public string TransactionId { get; set; }

        [XmlElement(Namespace = "")]
        public string Message { get; set; }
    }
}