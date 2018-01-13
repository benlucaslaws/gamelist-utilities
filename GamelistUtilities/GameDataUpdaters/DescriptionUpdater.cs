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
        private const string JAPANESE_CHARACTER_REGEX = "/[\\u3000-\\u303F]|[\\u3040-\\u309F]|[\\u30A0-\\u30FF]|[\\uFF00-\\uFFEF]|[\\u4E00-\\u9FAF]|[\\u2605-\\u2606]|[\\u2190-\\u2195]|\\u203B/g";

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

        public bool ContainsJapaneseCharacters(Game game)
        {
            Regex japaneseCharacterRegex = new Regex(JAPANESE_CHARACTER_REGEX);
            return japaneseCharacterRegex.IsMatch(game.Description);
        }
    }
}
