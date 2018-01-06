using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GamelistUtilities.Serializers
{
    public class GameListXmlSerializer: XmlSerializer
    {
        private XmlSerializerNamespaces Namespaces { get; }
        private string EncodingStyle = "UTF-8";

        public GameListXmlSerializer(Type t): base(t)
        {
            Namespaces = new XmlSerializerNamespaces();
            Namespaces.Add("", "");
        }

        public new void Serialize(Stream stream, object o)
        {
            base.Serialize(stream, o, Namespaces);
        }

        public new void Serialize(TextWriter textWriter, object o)
        {
            base.Serialize(textWriter, o, Namespaces);
        }

        public new void Serialize(XmlWriter xmlWriter, object o)
        {
            base.Serialize(xmlWriter, o, Namespaces, EncodingStyle);
        }
    }
}
