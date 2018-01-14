using GamelistUtilities.XmlDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GamelistUtilities.GameDataUpdaters
{
    public class NameUpdater
    {
        private const string PREFIX_THE = "The ";
        private const string SUFFIX_THE = ", The";
        private const string BRACKETS_REGEX = "\\(.*\\)";

        public void RemoveSpaceBeforeColons(Game game)
        {
            if (game.Name == null)
            {
                return;
            }

            game.Name = game.Name.Replace(" :", ":");
        }

        public void MoveTheToEndOfName(Game game)
        {
            if (game.Name == null)
            {
                return;
            }

            string formattedName = game.Name;

            if (formattedName.IndexOf(PREFIX_THE) == 0)
            {
                // Remove the 'The ' prefix
                formattedName = formattedName.Substring(PREFIX_THE.Length);
                int suffixTheIndex = GetSuffixTheIndex(formattedName);
                formattedName = formattedName.Insert(suffixTheIndex, SUFFIX_THE);
                game.Name = formattedName;
            }
        }

        private int GetSuffixTheIndex(string name)
        {
            int nameEndIndex = name.Length;
            int firstDashIndex = name.LastIndexOf(" - ");
            int firstColonIndexWithoutSpace = name.LastIndexOf(": ");
            int firstColonIndexWithSpace = name.LastIndexOf(" : ");
            int[] possibleSuffixPositions = {
                nameEndIndex,
                firstDashIndex,
                firstColonIndexWithoutSpace,
                firstColonIndexWithSpace
            };

            return possibleSuffixPositions
                .Where(position => position >= 0)
                .Min();
        }

        public bool ContainsBrackets(Game game)
        {
            Regex bracketsRegex = new Regex(BRACKETS_REGEX);
            return bracketsRegex.IsMatch(game.Name);
        }
    }
}
