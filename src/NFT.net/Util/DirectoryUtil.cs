// <copyright file="DirectoryUtil.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Util
{
    using System.IO;
    using System.Linq;

    public class DirectoryUtil
    {
        public static string[] GetFiles(string path, string[] patterns = null, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            if (patterns == null || patterns.Length == 0)
            {
                return Directory.GetFiles(path, "*", options);
            }

            if (patterns.Length == 1)
            {
                return Directory.GetFiles(path, patterns[0], options);
            }

            return patterns.SelectMany(pattern => Directory.GetFiles(path, pattern, options)).Distinct().ToArray();
        }
    }
}
