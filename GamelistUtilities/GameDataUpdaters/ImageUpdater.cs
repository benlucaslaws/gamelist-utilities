using GamelistUtilities.XmlDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamelistUtilities.GameDataUpdaters
{
    public class ImageUpdater
    {
        private const string PATH_FORMAT_FILENAME_PLACEHOLDER = "{ROM}";

        public void PopulateBlankImagePath(Game game, string pathFormat)
        {
            if (string.IsNullOrWhiteSpace(game.Image))
            {
                string fileName = GetFileName(game);
                string imagePath = pathFormat.Replace(PATH_FORMAT_FILENAME_PLACEHOLDER, fileName);
                game.Image = imagePath;
            }
        }

        private string GetFileName(Game game)
        {
            string filePath = game.Path;
            int fileNameIndex = filePath.LastIndexOf("/") + 1;
            int extensionIndex = filePath.LastIndexOf(".");
            int fileNameLength = extensionIndex - fileNameIndex;
            return filePath.Substring(fileNameIndex, fileNameLength);
        }
    }
}
