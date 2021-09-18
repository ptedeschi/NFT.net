// <copyright file="Metadata.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Based on Metadata Standards.
    /// https://docs.opensea.io/docs/metadata-standards.
    /// </summary>
    public class Metadata
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dna")]
        public string Dna { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("trait_type")]
        public string Layer { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
