// <copyright file="LayerHelper.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Helper
{
    using System.Collections.Generic;
    using System.IO;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Model;
    using Tedeschi.NFT.Util;
    using Weighted_Randomizer;

    public class LayerHelper
    {
        public static List<Layer> Load(string path)
        {
            var folders = Directory.GetDirectories(path);
            var layers = new List<Layer>();

            for (var i = 0; i < folders.Length; i++)
            {
                var randomizer = new DynamicWeightedRandomizer<int>();
                var folder = folders[i];
                var folderName = Path.GetFileName(folder);

                // Check to see if Layer folder structure is what we are expecting
                if (!ValidationUtil.IsValidLayerName(folderName))
                {
                    throw new InvalidLayerNamingException(folder);
                }

                var files = Directory.GetFiles(folder);

                var elements = new List<Element>();

                for (var j = 0; j < files.Length; j++)
                {
                    var file = files[j];
                    var filename = Path.GetFileNameWithoutExtension(file);

                    // If the filename has Weight information, extract it.
                    // Otherwise use Weight as the number of files present to represent 100%.
                    var weight = files.Length;

                    if (StringUtil.HasWeight(filename, Constants.WeightDelimiter))
                    {
                        weight = StringUtil.GetWeight(filename, Constants.WeightDelimiter);
                        filename = StringUtil.GetNameWithoutWeight(filename, Constants.WeightDelimiter);
                    }

                    var convertedCaseFilename = StringUtil.ToTitleCase(filename);

                    var element = new Element
                    {
                        Id = j,
                        Name = convertedCaseFilename,
                        Path = file,
                        Weight = weight,
                    };

                    randomizer.Add(element.Id, element.Weight);

                    elements.Add(element);
                }

                // Don't create Layer if it has no elements
                if (elements.Count == 0)
                {
                    break;
                }

                var folderNameWithoutNumber = StringUtil.GetName(folderName, Constants.LayerNamingDelimiter);
                var convertedCaseFolderName = StringUtil.ToTitleCase(folderNameWithoutNumber);

                var layer = new Layer
                {
                    Id = i,
                    Name = convertedCaseFolderName,
                    Elements = elements,
                    Randomizer = randomizer,
                };

                layers.Add(layer);
            }

            return layers;
        }
    }
}
