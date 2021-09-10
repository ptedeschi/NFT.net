// <copyright file="Constants.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT
{
    public static class Constants
    {
        public const char LayerNamingDelimiter = '-';
        public const int MaxDuplicateDnaRetries = 100;

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
        }

        public static class MetadataDefault
        {
            public const int DefaultType = MetadataType.None;
            public const string FolderName = "metadata";
            public const string MergedFilename = "metadata";
            public const string DefaultProjectName = "Made by NFT.net";
            public const string DefaultImageBaseUri = "https://someurl.com/nft";
        }

        public static class CollectionDefault
        {
            public const string DefaultSize = "10";
            public const string DefaultInitialNumber = "1";
            public const string DefaultFilenamePrefix = "nft #";
        }

        public static class FileExtension
        {
            public const string Png = ".png";
            public const string Json = ".json";
        }
    }
}
