// <copyright file="GeneratorService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Generator
{
    using System.Collections.Generic;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Model;

    internal class GeneratorService : IGeneratorService
    {
        public List<ImageDescriptor> Create(List<Layer> layers, int collectionSize)
        {
            var images = new List<ImageDescriptor>();
            var dic = new Dictionary<int, string>();

            var uniqueImagesCount = 0;
            var dnaDuplicatedAttempts = 0;

            while (uniqueImagesCount != collectionSize)
            {
                var imageDescriptor = this.UniqueImage(layers);

                if (!dic.ContainsValue(imageDescriptor.Dna))
                {
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
    }
}
