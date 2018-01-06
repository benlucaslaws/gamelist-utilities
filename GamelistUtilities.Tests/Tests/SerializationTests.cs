using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GamelistUtilities.XmlDataObjects;
using System.IO;
using GamelistUtilities.Serializers;

namespace GamelistUtilities.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void Test_Serialize()
        {
            GameList gameList = new GameList();
            gameList.Add(new Game()
            {
                Description = "Description",
                Developer = "Developer",
                Genre = "Genre",
                Id = "Id",
                Image = "Image",
                LastPlayed = "LastPlayed",
                Name = "Name",
                Path = "Path",
                PlayCount = "PlayCount",
                Players = "Players",
                Publisher = "Publisher",
                Rating = "Rating",
                ReleaseDate = "ReleaseDate",
                Source = "Source",
                Video = "Video"
            });

            GameListXmlSerializer xmlSerializer = new GameListXmlSerializer(typeof(GameList));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, gameList);

            string actualValue = stringWriter.ToString();
            string expectedValue = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<gameList>\r\n  <game id=\"Id\" source=\"Source\">\r\n    <desc>Description</desc>\r\n    <developer>Developer</developer>\r\n    <genre>Genre</genre>\r\n    <image>Image</image>\r\n    <lastplayed>LastPlayed</lastplayed>\r\n    <name>Name</name>\r\n    <path>Path</path>\r\n    <playcount>PlayCount</playcount>\r\n    <players>Players</players>\r\n    <publisher>Publisher</publisher>\r\n    <rating>Rating</rating>\r\n    <releasedate>ReleaseDate</releasedate>\r\n    <video>Video</video>\r\n  </game>\r\n</gameList>";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_Deserialize()
        {
            string xmlString = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<gameList>\r\n  <game id=\"Id\" source=\"Source\">\r\n    <desc>Description</desc>\r\n    <developer>Developer</developer>\r\n    <genre>Genre</genre>\r\n    <image>Image</image>\r\n    <lastplayed>LastPlayed</lastplayed>\r\n    <name>Name</name>\r\n    <path>Path</path>\r\n    <playcount>PlayCount</playcount>\r\n    <players>Players</players>\r\n    <publisher>Publisher</publisher>\r\n    <rating>Rating</rating>\r\n    <releasedate>ReleaseDate</releasedate>\r\n    <video>Video</video>\r\n  </game>\r\n</gameList>";
            GameListXmlSerializer xmlSerializer = new GameListXmlSerializer(typeof(GameList));
            StringReader stringReader = new StringReader(xmlString);
            GameList list = xmlSerializer.Deserialize(stringReader) as GameList;
            Assert.True(list.Count == 1 &&
                list[0].Description == "Description" &&
                list[0].Developer == "Developer" &&
                list[0].Genre == "Genre" &&
                list[0].Id == "Id" &&
                list[0].Image == "Image" &&
                list[0].LastPlayed == "LastPlayed" &&
                list[0].Name == "Name" &&
                list[0].Path == "Path" &&
                list[0].PlayCount == "PlayCount" &&
                list[0].Players == "Players" &&
                list[0].Publisher == "Publisher" &&
                list[0].Rating == "Rating" &&
                list[0].ReleaseDate == "ReleaseDate" &&
                list[0].Source == "Source" &&
                list[0].Video == "Video");
        }
    }
}
