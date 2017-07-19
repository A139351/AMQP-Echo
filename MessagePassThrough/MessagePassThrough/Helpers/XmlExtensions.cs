using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MessagePassThrough
{
    public static class XmlExtensions
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null) return string.Empty;

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("ns0", "urn:agl.com.au:azure:servicebus:common");
                    xmlSerializer.Serialize(xmlWriter, value, ns);
                    return stringWriter.ToString();
                }
            }
        }

        public static T Deserialize<T>(this string value)
        {
            var serializer = new XmlSerializer(typeof(T));
            var rdr = new StringReader(value);
            return (T)serializer.Deserialize(rdr);
        }
    }

}