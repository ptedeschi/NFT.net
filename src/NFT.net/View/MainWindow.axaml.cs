// <copyright file="MainWindow.axaml.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace NFT.net.View
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Interactivity;
    using Avalonia.Markup.Xaml;
    using Tedeschi.NFT.Services.Collection;
    using Tedeschi.NFT.Services.Layer;
    using Tedeschi.NFT.Services.Metadata;

    public partial class MainWindow : Window
    {
        private readonly ILayerService layerService;
        private readonly ICollectionService collectionService;
        private readonly IMetadataService metadataService;

        private TextBox textBoxLayersFolder;
        private TextBox textBoxOutputFolder;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainWindow(ILayerService layerService, ICollectionService collectionService, IMetadataService metadataService)
        {
            this.InitializeComponent();

            this.layerService = layerService;
            this.collectionService = collectionService;
            this.metadataService = metadataService;

            this.textBoxLayersFolder = this.FindControl<TextBox>("textBoxLayersFolder");
            this.textBoxOutputFolder = this.FindControl<TextBox>("textBoxOutputFolder");

            var productName = Assembly.GetExecutingAssembly().GetName().Name;
            var productVersion = Assembly.GetExecutingAssembly().GetName().Version;

            this.Title = $"{productName} v{productVersion}";

            this.MaxWidth = 600;
            this.MinWidth = 600;

            this.MaxHeight = 650;
            this.MinHeight = 650;

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private async void ButtonLayersFolderOnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog()
            {
                Title = "Select Folder...",
            };

            var result = await dialog.ShowAsync(this);

            if (result != null)
            {
                this.textBoxLayersFolder.Text = result;
            }
        }

        private async void ButtonOutputFolderOnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog()
            {
                Title = "Select Folder...",
            };

            var result = await dialog.ShowAsync(this);

            if (result != null)
            {
                this.textBoxOutputFolder.Text = result;
            }
        }

        private void ButtonGenerateOnClick(object sender, RoutedEventArgs e)
        {
            var layersFolder = @"";
            var outputFolder = @"";

            var metadataType = 2;
            var metadataDescription = "Made by NFT.net";
            var metadataImageBaseUri = "https://someurl.com/nft";

            var collectionSize = 10;
            var collectionInitialNumber = 1;
            var collectionImagePrefix = "nft #";

            this.collectionService.Create(layersFolder, outputFolder, metadataType, metadataDescription, metadataImageBaseUri, collectionSize, collectionInitialNumber, collectionImagePrefix);
        }
    }
}
