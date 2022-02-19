// <copyright file="LayerService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Layer
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Mechanism;
    using Tedeschi.NFT.Model;
    using Tedeschi.NFT.Util;

    internal class LayerService : ILayerService
    {
        public List<Layer> Load(string path)
        {
            var folders = Directory.GetDirectories(path);

            // Ensure layers are sorted correctly
            folders = folders.OrderBy(x => x).ToArray();

            return this.HandleLayers(folders);
        }

        private List<Layer> HandleLayers(string[] folders)
        {
            var layers = new List<Layer>();

            for (var i = 0; i < folders.Length; i++)
            {
                var randomizer = new WeightedRandomizer<int>();
                var folder = folders[i];
                var folderName = Path.GetFileName(folder);

                // Check to see if Layer folder structure is what we are expecting
                if (!ValidationUtil.IsValidLayerName(folderName))
                {
                    throw new InvalidLayerNamingException(folder);
                }

                var files = DirectoryUtil.GetFiles(folder, Constants.SupportedImageFormats, SearchOption.AllDirectories);

                var elements = this.HandleElements(files, randomizer);

                // Don't create Layer if it has no elements
                if (elements.Count > 0)
                {
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
            }

            return layers;
        }

        private List<Element> HandleElements(string[] files, WeightedRandomizer<int> randomizer)
        {
            var elements = new List<Element>();

            for (var j = 0; j < files.Length; j++)
            {
                var file = files[j];

                // Handle weight
                var elementWeight = this.HandleElementWeight(files, file);

                var convertedCaseFilename = StringUtil.ToTitleCase(elementWeight.Filename);

                var element = new Element
                {
                    Id = j,
                    Name = convertedCaseFilename,
                    Path = file,
                    Weight = elementWeight.Weight,
                };

                randomizer.Add(element.Id, element.Weight);

                elements.Add(element);
            }

            return elements;
        }

        private dynamic HandleElementWeight(string[] files, string file)
        {
            dynamic elementWeight;

            int weight;
            string filename;

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

            if (StringUtil.HasWeight(fileNameWithoutExtension, Constants.WeightDelimiter))
            {
                // If the filename has Weight information, extract it
                weight = StringUtil.GetWeight(fileNameWithoutExtension, Constants.WeightDelimiter);
                filename = StringUtil.GetNameWithoutWeight(fileNameWithoutExtension, Constants.WeightDelimiter);
            }
            else
            {
                // Otherwise use Weight as 100%
                weight = 100;
                filename = fileNameWithoutExtension;
            }

            elementWeight = new ExpandoObject();
            elementWeight.Weight = weight;
            elementWeight.Filename = filename;

            return elementWeight;
        }
    }
}
