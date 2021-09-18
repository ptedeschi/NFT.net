// <copyright file="ICollectionService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Collection
{
    public interface ICollectionService
    {
        void Create(string layersFolder, string outputFolder, int metadataType, string metadataDescription, string metadataImageBaseUri, int collectionSize, int collectionInitialNumber, string collectionImagePrefix);
    }
}
