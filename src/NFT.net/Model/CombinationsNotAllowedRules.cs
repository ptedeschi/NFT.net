// <copyright file="CombinationsNotAllowedRules.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Model
{
    public class CombinationsNotAllowedRules
    {
        public Combination[] Combinations { get; set; }
    }

    public class Combination
    {
        public string LayerName_1 { get; set; }

        public string ElementName_1 { get; set; }

        public string LayerName_2 { get; set; }

        public string ElementName_2 { get; set; }
    }
}
