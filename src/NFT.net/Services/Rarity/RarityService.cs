// <copyright file="RarityService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Metadata
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Tedeschi.NFT.Model;

    /// <summary>
    /// Generates a rarity file based on the following method:
    /// [Rarity Score for a Trait Value] = 1 / ([Number of Items with that Trait Value] / [Total Number of Items in Collection])
    ///  The total Rarity Score for an NFT is the sum of the Rarity Score of all of its trait values.
    ///  This is the method used by Rarity Tools - https://rarity.tools/.
    ///  </summary>
    internal class RarityService : IRarityService
    {
        public void Generate(string outputFolder, List<Metadata> metadataList, int type)
        {
            var rarityLocation = $"{outputFolder}{Path.DirectorySeparatorChar}{Constants.RarityDefault.FolderName}";
            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            if (!Directory.Exists(rarityLocation))
            {
                Directory.CreateDirectory(rarityLocation);
            }

            var traitCounts = new Dictionary<string, Dictionary<string, int>>();
            this.BuildTraitDictionary(metadataList, traitCounts);
            var collectionSize = metadataList.Count;

            var rarities = new List<RarityData>();
            double rarityTotal;
            foreach (var metadata in metadataList)
            {
                rarityTotal = 0;
                foreach (var attribute in metadata.Attributes)
                {
                    var traitCountsForAttribute = traitCounts.Where(t => t.Key == attribute.Layer).FirstOrDefault().Value;
                    double attributeRarity = 1 / (double)(traitCountsForAttribute[attribute.Value] / (double)collectionSize);
                    rarityTotal += attributeRarity;
                }

                rarities.Add(new RarityData
                {
                    Id = metadata.Id,
                    Rarity = rarityTotal,
                });
            }

            var sortedDict = from entry in rarities orderby entry.Rarity descending select entry;

            foreach (var metadata in metadataList)
            {
                var jsonMerged = JsonConvert.SerializeObject(sortedDict, Formatting.Indented, serializerSettings);
                File.WriteAllText($"{rarityLocation}{Path.DirectorySeparatorChar}{Constants.RarityDefault.MergedFilename}{Constants.FileExtension.Json}", jsonMerged);
            }
        }

        private void BuildTraitDictionary(List<Metadata> metadataList, Dictionary<string, Dictionary<string, int>> traitCommonalities)
        {
            IEnumerable<string> attributes = new List<string>();
            foreach (var metadata in metadataList)
            {
                attributes = metadataList.First().Attributes.Select(a => a.Layer).Distinct();
            }

            foreach (var attributeName in attributes)
            {
                var valuesForAttribute = metadataList.SelectMany(m => m.Attributes.Where(a => a.Layer == attributeName).Select(a => a.Value)).Distinct();
                var traitDictionary = new Dictionary<string, int>();

                foreach (var value in valuesForAttribute)
                {
                    var valueCount = metadataList.SelectMany(m => m.Attributes.Where(a => a.Layer == attributeName && a.Value == value)).Count();
                    traitDictionary.Add(value, valueCount);
                }

                traitCommonalities.Add(attributeName, traitDictionary);
            }
        }
    }
}