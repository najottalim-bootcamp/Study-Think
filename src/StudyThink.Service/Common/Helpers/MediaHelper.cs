﻿namespace StudyThink.Service.Common.Helpers
{
    public class MediaHelper
    {
        /// <summary>
        /// This function create unique Image Name
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string MakeImageName(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            string[] ImageExtension = GetImageExtensions();

            if (ImageExtension.Any(x => x == fileInfo.Extension))
            {
                string extension = fileInfo.Extension;
                string name = "IMG_" + Guid.NewGuid() + extension;
                return name;
            }
            return null;
        }


        public static string[] GetImageExtensions()
        {
            return new string[]
            {
            // JPG files
            ".jpg", ".jpeg",
            // Png files
            ".png",
            // Bmp files
            ".bmp",
            // Svg files
            ".svg"
            };
        }
    }
}
