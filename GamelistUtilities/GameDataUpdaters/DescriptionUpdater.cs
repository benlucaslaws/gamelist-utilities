using GamelistUtilities.XmlDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GamelistUtilities.Extensions;

namespace GamelistUtilities.GameDataUpdaters
{
    public class DescriptionUpdater
    {
        private const string ARCADE_HISTORY_HEADER_REGEX = "^.*(C).*";
        private const string ARCADE_HISTORY_FOOTER_REGEX = "\\(C\\) arcade-history.com$";

        public void RemoveArcadeHistoryHeader(Game game)
        {
            Regex headerRegex = new Regex(ARCADE_HISTORY_HEADER_REGEX);
            string formattedDescription = game.Description.TrimStart();
            formattedDescription = headerRegex.Replace(game.Description, string.Empty);
            formattedDescription = formattedDescription.TrimStart();
            game.Description = formattedDescription;
        }

        public void RemoveArcadeHistoryFooter(Game game)
        {
            Regex footerRegex = new Regex(ARCADE_HISTORY_FOOTER_REGEX);
            string formattedDescription = game.Description.TrimEnd();
            formattedDescription = footerRegex.Replace(game.Description, string.Empty);
            formattedDescription = formattedDescription.TrimEnd();
            game.Description = formattedDescription;
        }

        public void ReplaceUnrenderableCharacterReferences(Game game, char oldChar, char? newChar = null)
        {
            if (newChar == null)
            {
                newChar = oldChar;
            }

            string formattedDecription = game.Description;
            string replacementCharacterString = newChar.ToString();
            string hexReference = oldChar.ToHexadecimalReference();
            string decReference = oldChar.ToDecimalReference();
            string htmlEncodedReference = oldChar.ToHtmlEncoded();
            formattedDecription = formattedDecription
                .Replace(oldChar, newChar.Value)
                .Replace(hexReference, replacementCharacterString)
                .Replace(decReference, replacementCharacterString)
                .Replace(htmlEncodedReference, replacementCharacterString);
            game.Description = formattedDecription;

        }
    }
}
