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
    }
}
