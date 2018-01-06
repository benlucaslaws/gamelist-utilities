using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GamelistUtilities.XmlDataObjects
{
    [XmlType("game")]
    public class Game
    {
        [XmlElement("desc")]
        public string Description { get; set; }
        [XmlElement("developer")]
        public string Developer { get; set; }
        [XmlElement("genre")]
        public string Genre { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("image")]
        public string Image { get; set; }
        [XmlElement("lastplayed")]
        public string LastPlayed { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("path")]
        public string Path { get; set; }
        [XmlElement("playcount")]
        public string PlayCount { get; set; }
        [XmlElement("players")]
        public string Players { get; set; }
        [XmlElement("publisher")]
        public string Publisher { get; set; }
        [XmlElement("rating")]
        public string Rating { get; set; }
        [XmlElement("releasedate")]
        public string ReleaseDate { get; set; }
        [XmlAttribute("source")]
        public string Source { get; set; }
        [XmlElement("video")]
        public string Video { get; set; }
    }
}
