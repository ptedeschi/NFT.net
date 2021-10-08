namespace NFT.net.View
{
    using Autofac;
    using Avalonia;
    using Avalonia.Controls.ApplicationLifetimes;
    using Avalonia.Markup.Xaml;
    using Tedeschi.NFT.Services.Collection;
    using Tedeschi.NFT.Services.Generator;
    using Tedeschi.NFT.Services.Image;
    using Tedeschi.NFT.Services.Layer;
    using Tedeschi.NFT.Services.Metadata;

    public class App : Application
    {
        private static IContainer container;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Get instance of Autofac Container
                container = Configure();

                desktop.MainWindow = new MainWindow(container.Resolve<ILayerService>(), container.Resolve<ICollectionService>(), container.Resolve<IMetadataService>());
            }

            base.OnFrameworkInitializationCompleted();
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

            return builder.Build();
        }
    }
}
