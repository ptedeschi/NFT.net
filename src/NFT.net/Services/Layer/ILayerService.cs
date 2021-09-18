// <copyright file="ILayerService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Layer
{
    using System.Collections.Generic;
    using Tedeschi.NFT.Model;

    public interface ILayerService
    {
        List<Layer> Load(string path);
    }
}
