using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace MessagePassThrough.Contracts
{
    [XmlRoot(Namespace = "urn:agl.com.au:azure:servicebus:common")]
    public class Request
    {
        //<ns0:Request xmlns:ns0="urn:agl.com.au:azure:servicebus:common">
            //<NameId>AGL_001517D12F601EE48D9DB0BFBEA08CD</NameId>
        //</ns0:Request>
        [XmlElement(Namespace="")]
        public string NameId { get; set; }
    }
}