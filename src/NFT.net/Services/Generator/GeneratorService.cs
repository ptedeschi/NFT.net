// <copyright file="GeneratorService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Generator
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Model;
    using static Tedeschi.NFT.Constants;

    internal class GeneratorService : IGeneratorService
    {
        public List<ImageDescriptor> Create(List<Layer> layers, int collectionSize, string layersFolder)
        {
            var images = new List<ImageDescriptor>();
            var dic = new Dictionary<int, string>();

            // Load predefined images (if available)
            var presetDna = this.GetPresetDna(layersFolder);

            if (presetDna != null && presetDna.Preset != null && presetDna.Preset.Length > 0 && presetDna.Preset.Length < collectionSize)
            {
                foreach (var dna in presetDna.Preset)
                {
                    images.Add(this.DnaToImageDescriptor(layers, dna));
                }
            }

            var uniqueImagesCount = images.Count;
            var dnaDuplicatedAttempts = 0;

            while (uniqueImagesCount != collectionSize)
            {
                var imageDescriptor = this.UniqueImage(layers);

                if (!dic.ContainsValue(imageDescriptor.Dna))
                {
                    if (!this.IsCombinationAllowed(this.GetCombinationRules(layersFolder), imageDescriptor))
                    {
                        continue;
                    }

                    dic.Add(uniqueImagesCount, imageDescriptor.Dna);
                    images.Add(imageDescriptor);

                    uniqueImagesCount++;

                    // Reset DNA retry attempts
                    dnaDuplicatedAttempts = 0;
                }
                else
                {
                    if (dnaDuplicatedAttempts >= Constants.MaxDuplicateDnaRetries)
                    {
                        throw new DuplicateDnaAttemptsException();
                    }

                    dnaDuplicatedAttempts++;
                }
            }

            return images;
        }

        private ImageDescriptor UniqueImage(List<Layer> layers)
        {
            var attributes = new List<ImageAttribute>();
            var files = new List<string>();
            var dna = new List<int>();

            foreach (var layer in layers)
            {
                var index = layer.Randomizer.Select();

                var attribute = new ImageAttribute
                {
                    Layer = layer.Name,
                    Value = layer.Elements[index].Name,
                    File = layer.Elements[index].Path,
                };

                attributes.Add(attribute);
                files.Add(attribute.File);
                dna.Add(index);
            }

            return new ImageDescriptor { Dna = string.Join("-", dna), Files = files, Attributes = attributes };
        }

        private ImageDescriptor DnaToImageDescriptor(List<Layer> layers, string dna)
        {
            var numbers = dna.Split('-').Select(int.Parse).ToList();

            var attributes = new List<ImageAttribute>();
            var files = new List<string>();
            var layer = 0;

            foreach (var index in numbers)
            {
                var attribute = new ImageAttribute
                {
                    Layer = layers[layer].Name,
                    Value = layers[layer].Elements[index].Name,
                    File = layers[layer].Elements[index].Path,
                };

                attributes.Add(attribute);
                files.Add(attribute.File);

                layer++;
            }

            return new ImageDescriptor { Dna = dna, Files = files, Attributes = attributes };
        }

        private CombinationsNotAllowedRules GetCombinationRules(string layersFolder)
        {
            CombinationsNotAllowedRules combinationRules = null;

            try
            {
                var rulesFile = $"{layersFolder}{Path.DirectorySeparatorChar}{CombinationRules.FileName}";

                combinationRules = new CombinationsNotAllowedRules();
                var temp = JsonConvert.DeserializeObject<List<Combination>>(File.ReadAllText(rulesFile));
                combinationRules.Combinations = temp.ToArray();
            }
            catch
            {
            }

            return combinationRules;
        }

        private PresetDna GetPresetDna(string layersFolder)
        {
            PresetDna presetDna = null;

            try
            {
                var file = $"{layersFolder}{Path.DirectorySeparatorChar}{PresetDnaConfig.FileName}";
                presetDna = JsonConvert.DeserializeObject<PresetDna>(File.ReadAllText(file));
            }
            catch
            {
            }

            return presetDna;
        }

        private bool IsCombinationAllowed(CombinationsNotAllowedRules rules, ImageDescriptor descriptor)
        {
            if (rules != null && rules.Combinations != null)
            {
                foreach (var combination in rules.Combinations)
                {
                    // Get the image attribute that contains the layer mentioned in the rules
                    var layer_1 = descriptor.Attributes.Where(a => a.Layer.ToLower().Contains(combination.LayerName_1.ToLower())).FirstOrDefault();
                    var layer_2 = descriptor.Attributes.Where(a => a.Layer.ToLower().Contains(combination.LayerName_2.ToLower())).FirstOrDefault();

                    // Check if it's not avoiding the whole trait
                    if (combination.ElementName_1.Equals(CombinationRules.WildcardSymbol))
                    {
                        if (layer_1 != null && !layer_1.Value.ToLower().Equals(CombinationRules.WildcardExceptionFilename) && layer_2.Value.ToLower().Equals(combination.ElementName_2.ToLower()))
                        {
                            return false;
                        }
                    }

                    // Check if it's not avoiding the whole trait
                    if (combination.ElementName_2.Equals(CombinationRules.WildcardSymbol))
                    {
                        if (layer_1.Value.ToLower().Equals(combination.ElementName_1.ToLower()) && layer_2 != null && !layer_2.Value.ToLower().Equals(CombinationRules.WildcardExceptionFilename))
                        {
                            return false;
                        }
                    }

                    if (layer_1.Value.ToLower().Equals(combination.ElementName_1.ToLower()) && layer_2.Value.ToLower().Equals(combination.ElementName_2.ToLower()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
