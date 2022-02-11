// <copyright file="Program.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT
{
    using System;
    using System.Windows.Forms;
    using Autofac;
    using Tedeschi.NFT.Services.Collection;
    using Tedeschi.NFT.Services.Generator;
    using Tedeschi.NFT.Services.Image;
    using Tedeschi.NFT.Services.Layer;
    using Tedeschi.NFT.Services.Metadata;
    using Tedeschi.NFT.View;

    /// <summary>
    /// Program entry point.
    /// </summary>
    public static class Program
    {
        private static IContainer container;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Get instance of Autofac Container
            container = Configure();

            Application.Run(new MainForm(container.Resolve<ILayerService>(), container.Resolve<ICollectionService>(), container.Resolve<IMetadataService>()));
        }

        /// <summary>
        /// Setting Dependency Injection.
        /// </summary>
        /// <returns>A new container with the configured component registrations.</returns>
        private static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CollectionService>().As<ICollectionService>();
            builder.RegisterType<LayerService>().As<ILayerService>();
            builder.RegisterType<ImageService>().As<IImageService>();
            builder.RegisterType<GeneratorService>().As<IGeneratorService>();
            builder.RegisterType<MetadataService>().As<IMetadataService>();
            builder.RegisterType<RarityService>().As<IRarityService>();

            return builder.Build();
        }
    }
}
