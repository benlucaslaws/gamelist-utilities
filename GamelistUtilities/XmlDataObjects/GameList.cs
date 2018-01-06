using System.Collections.Generic;
using System.Xml.Serialization;

namespace GamelistUtilities.XmlDataObjects
{
    [XmlRoot("gameList")]
    public class GameList: List<Game>
    {
    }
}
