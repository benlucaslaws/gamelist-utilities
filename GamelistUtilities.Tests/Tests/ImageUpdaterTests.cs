using GamelistUtilities.GameDataUpdaters;
using GamelistUtilities.XmlDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamelistUtilities.Tests.Tests
{
    public class ImageUpdaterTests
    {
        [Fact]
        public void Test_ReplaceBlankImage()
        {
            Game game = new Game()
            {
                Path = "./Game.zip",
                Image = ""
            };

            ImageUpdater imageUpdater = new ImageUpdater();
            string imageFormat = "./images/covers/{ROM}-image.jpg";
            imageUpdater.PopulateBlankImagePath(game, imageFormat);
            string actualValue = game.Image;
            string expectedValue = "./images/covers/Game-image.jpg";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_DontReplaceNonBlankImage()
        {
            Game game = new Game()
            {
                Path = "./Game.zip",
                Image = "./gamecover.png"
            };

            ImageUpdater imageUpdater = new ImageUpdater();
            string imageFormat = "./images/covers/{ROM}-image.jpg";
            imageUpdater.PopulateBlankImagePath(game, imageFormat);
            string actualValue = game.Image;
            string expectedValue = "./gamecover.png";
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
