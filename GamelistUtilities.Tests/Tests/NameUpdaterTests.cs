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
    public class NameUpdaterTests
    {
        [Fact]
        public void Test_MoveTheToEndOfName_NoPrefixThe()
        {
            Game game = new Game()
            {
                Name = "Game"
            };

            NameUpdater nameUpdater = new NameUpdater();
            nameUpdater.MoveTheToEndOfName(game);
            string actualValue = game.Name;
            string expectedValue = "Game";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_MoveTheToEndOfName_PrefixTheNoPunctuation()
        {
            Game game = new Game()
            {
                Name = "The Game"
            };

            NameUpdater nameUpdater = new NameUpdater();
            nameUpdater.MoveTheToEndOfName(game);
            string actualValue = game.Name;
            string expectedValue = "Game, The";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_MoveTheToEndOfName_PrefixTheDash()
        {
            Game game = new Game()
            {
                Name = "The Game - Subtitle"
            };

            NameUpdater nameUpdater = new NameUpdater();
            nameUpdater.MoveTheToEndOfName(game);
            string actualValue = game.Name;
            string expectedValue = "Game, The - Subtitle";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_MoveTheToEndOfName_PrefixTheColonWithSpace()
        {
            Game game = new Game()
            {
                Name = "The Game : Subtitle"
            };

            NameUpdater nameUpdater = new NameUpdater();
            nameUpdater.MoveTheToEndOfName(game);
            string actualValue = game.Name;
            string expectedValue = "Game, The : Subtitle";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_MoveTheToEndOfName_PrefixTheColonNoSpace()
        {
            Game game = new Game()
            {
                Name = "The Game: Subtitle"
            };

            NameUpdater nameUpdater = new NameUpdater();
            nameUpdater.MoveTheToEndOfName(game);
            string actualValue = game.Name;
            string expectedValue = "Game, The: Subtitle";
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Test_RemoveSpaceBeforeColons()
        {
            Game game = new Game()
            {
                Name = "The Game : Subtitle"
            };

            NameUpdater nameUpdater = new NameUpdater();
            nameUpdater.RemoveSpaceBeforeColons(game);
            string actualValue = game.Name;
            string expectedValue = "The Game: Subtitle";
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
