// <copyright file="StringUtil.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Util
{
    using System.Globalization;

    public class StringUtil
    {
        public static string ToTitleCase(string text)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(text);
        }

        public static string GetName(string file, char delimiter)
        {
            var index = file.IndexOf(delimiter);

            return file.Substring(index + 1);
        }

        public static bool HasWeight(string filename, char delimiter)
        {
            try
            {
                var index = filename.LastIndexOf(delimiter);
                var weight = filename.Substring(index + 1);

                int.Parse(weight);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetNameWithoutWeight(string filename, char delimiter)
        {
            try
            {
                var index = filename.LastIndexOf(delimiter);
                var nameWithoutWeight = filename.Substring(0, index);

                return nameWithoutWeight;
            }
            catch
            {
                return filename;
            }
        }

        public static int GetWeight(string filename, char delimiter)
        {
            var index = filename.LastIndexOf(delimiter);
            var weight = filename.Substring(index + 1);

            return int.Parse(weight);
        }
    }
}
