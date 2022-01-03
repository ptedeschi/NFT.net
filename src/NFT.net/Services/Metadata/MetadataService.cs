// <copyright file="MetadataService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Metadata
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Tedeschi.NFT.Model;

    internal class MetadataService : IMetadataService
    {
        public void Generate(string outputFolder, List<Metadata> metadataList, int type)
        {
            var metadataLocation = $"{outputFolder}{Path.DirectorySeparatorChar}{Constants.MetadataDefault.FolderName}";
            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            switch (type)
            {
                case Constants.MetadataType.None:
                    break;

                case Constants.MetadataType.Merged:
                    if (!Directory.Exists(metadataLocation))
                    {
                        Directory.CreateDirectory(metadataLocation);
                    }

                    var jsonMerged = JsonConvert.SerializeObject(metadataList, Formatting.Indented, serializerSettings);
                    File.WriteAllText($"{metadataLocation}{Path.DirectorySeparatorChar}{Constants.MetadataDefault.MergedFilename}{Constants.FileExtension.Json}", jsonMerged);
                    break;

                case Constants.MetadataType.Individual:
                    if (!Directory.Exists(metadataLocation))
                    {
                        Directory.CreateDirectory(metadataLocation);
                    }

                    foreach (var metadata in metadataList)
                    {
                        var jsonIndividual = JsonConvert.SerializeObject(metadata, Formatting.Indented, serializerSettings);
                        File.WriteAllText($"{metadataLocation}{Path.DirectorySeparatorChar}{metadata.Id}{Constants.FileExtension.Json}", jsonIndividual);
                    }

                    break;
            }
        }

        public void Update(string outputFolder, string newImageBaseUri, int type)
        {
            var metadataLocation = $"{outputFolder}{Path.DirectorySeparatorChar}{Constants.MetadataDefault.FolderName}";

            switch (type)
            {
                case Constants.MetadataType.None:
                    break;

                case Constants.MetadataType.Merged:
                    {
                        var filename = $"{metadataLocation}{Path.DirectorySeparatorChar}{Constants.MetadataDefault.MergedFilename}{Constants.FileExtension.Json}";
                        var list = JsonConvert.DeserializeObject<List<Metadata>>(File.ReadAllText(filename));

                        foreach (var item in list)
                        {
                            item.Image = $"{newImageBaseUri}/{item.Filename}";
                        }

                        this.Generate(outputFolder, list, type);
                    }

                    break;

                case Constants.MetadataType.Individual:
                    {
                        var list = new List<Metadata>();

                        foreach (string filename in Directory.GetFiles(metadataLocation, $"*{Constants.FileExtension.Json}"))
                        {
                            var metadata = JsonConvert.DeserializeObject<Metadata>(File.ReadAllText(filename));
                            metadata.Image = $"{newImageBaseUri}/{metadata.Filename}";

                            list.Add(metadata);
                        }

                        this.Generate(outputFolder, list, type);
                    }

                    break;
            }
        }
    }
}
