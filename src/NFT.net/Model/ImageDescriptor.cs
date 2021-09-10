// <copyright file="ImageDescriptor.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Model
{
    using System.Collections.Generic;

    public class ImageDescriptor
    {
        public string Dna { get; set; }

        public List<ImageAttribute> Attributes { get; set; }

        public List<string> Files { get; set; }
    }

    public class ImageAttribute
    {
        public string Layer { get; set; }

        public string Value { get; set; }

        public string File { get; set; }
    }
}
