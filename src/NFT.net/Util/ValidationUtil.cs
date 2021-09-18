// <copyright file="ValidationUtil.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Util
{
    using System;

    public class ValidationUtil
    {
        public static bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        public static bool IsUri(string text)
        {
            return Uri.TryCreate(text, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == "ipfs");
        }

        public static bool IsValidLayerName(string layerName)
        {
            if (!string.IsNullOrWhiteSpace(layerName))
            {
                var index = layerName.IndexOf(Constants.LayerNamingDelimiter);

                if (index != -1)
                {
                    var layerNumber = layerName.Substring(0, index);

                    if (IsNumeric(layerNumber))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
