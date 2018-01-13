using GamelistUtilities.GameDataUpdaters;
using GamelistUtilities.XmlDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamelistUtilities.Tests
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

        [Theory]
        [InlineData("Game &#x26; Game", '&', '&', "Game & Game")]
        [InlineData("Game &#38; Game", '&', '&', "Game & Game")]
        [InlineData("Game &amp; Game", '&', '&', "Game & Game")]
        [InlineData("Game & Game", '&', '&', "Game & Game")]
        [InlineData("Game & Game", '&', '+', "Game + Game")]
        public void Test_ReplaceUnrenderableCharacterReferences(string description, char oldChar, char newChar, string expectedValue)
        {
            Game game = new Game()
            {
                Description = description
            };

            DescriptionUpdater descriptionUpdater = new DescriptionUpdater();
            descriptionUpdater.ReplaceUnrenderableCharacterReferences(game, oldChar, newChar);
            string actualValue = game.Description;
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("げえむ", true)]
        [InlineData("ゲーム", true)]
        [InlineData("競技", true)]
        [InlineData("Game", false)]
        public void Test_ContainsJapaneseCharacters(string description, bool expectedValue)
        {
            Game game = new Game()
            {
                Description = description
            };

            DescriptionUpdater descriptionUpdater = new DescriptionUpdater();
            bool actualValue = descriptionUpdater.ContainsJapaneseCharacters(game);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
