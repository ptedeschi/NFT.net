// <copyright file="Constants.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT
{
    public static class Constants
    {
        public const char LayerNamingDelimiter = '-';
        public const char WeightDelimiter = '+';
        public const string ImagesFolderName = "images";
        public const int MaxDuplicateDnaRetries = 100;
        public static readonly string[] SupportedImageFormats = new[] { "*.jpg", "*.jpeg", "*.png" };

        public static class About
        {
            public const string SiteUrl = "https://github.com/ptedeschi/NFT.net";
            public const string WalletNetwork = "Ethereum (ERC20)";
            public const string WalletAddress = "0x893615196509526dbf85428d284658d12a6dc773";
        }

        public static class MetadataType
        {
            public const int None = 0;
            public const int Merged = 1;
            public const int Individual = 2;
            public const int Both = 3;
        }

        public static class MetadataDefault
        {
            public const string FolderName = "metadata";
            public const string FolderName2 = "Individual";
            public const string FolderName3 = "Merged";
            public const string MergedFilename = "metadata";
        }

        public static class RarityDefault
        {
            public const string FolderName = "rarities";
            public const string MergedFilename = "rarities";
        }

        public static class FileExtension
        {
            public const string Png = ".png";
            public const string Json = ".json";
        }

        public static class CombinationRules
        {
            public const string FileName = "rules.json";
            public const string WildcardSymbol = "*";
            public const string WildcardExceptionFilename = "none";
        }

        public static class PresetDnaConfig
        {
            public const string FileName = "preset.json";
        }
    }
}
