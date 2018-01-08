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
    public class DescriptionUpdaterTests
    {
        [Fact]
        public void Test_RemoveArcadeHistoryHeader_RemovesHeader()
        {
            Game game = new Game()
            {
                Description = "Game (C) 1992 Game Company\n\nDescription\n\n(C) arcade-history.com"
            };

            DescriptionUpdater descriptionUpdater = new DescriptionUpdater();
            descriptionUpdater.RemoveArcadeHistoryHeader(game);
            string actualValue = game.Description;
            string expectedValue = "Description\n\n(C) arcade-history.com";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_RemoveArcadeHistoryHeader_DoesNotRemoveHeaderLikeTextInBody()
        {
            Game game = new Game()
            {
                Description = "Game (C) 1992 Game Company\n\nDescription. Game (C) 1992 Game Company\n\n(C) arcade-history.com"
            };

            DescriptionUpdater descriptionUpdater = new DescriptionUpdater();
            descriptionUpdater.RemoveArcadeHistoryHeader(game);
            string actualValue = game.Description;
            string expectedValue = "Description. Game (C) 1992 Game Company\n\n(C) arcade-history.com";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_RemoveArcadeHistoryFooter_RemovesFooter()
        {
            Game game = new Game()
            {
                Description = "Game (C) 1992 Game Company\n\nDescription\n\n(C) arcade-history.com"
            };

            DescriptionUpdater descriptionUpdater = new DescriptionUpdater();
            descriptionUpdater.RemoveArcadeHistoryFooter(game);
            string actualValue = game.Description;
            string expectedValue = "Game (C) 1992 Game Company\n\nDescription";
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
