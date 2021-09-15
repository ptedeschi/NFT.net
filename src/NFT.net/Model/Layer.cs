// <copyright file="Layer.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Model
{
    using System.Collections.Generic;
    using Weighted_Randomizer;

    public class Layer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Element> Elements { get; set; }

        public IWeightedRandomizer<int> Randomizer { get; set; }
    }
}
