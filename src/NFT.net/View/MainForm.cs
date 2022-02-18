// <copyright file="MainForm.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.View
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Tedeschi.NFT.Event;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Resources;
    using Tedeschi.NFT.Services.Collection;
    using Tedeschi.NFT.Services.Layer;
    using Tedeschi.NFT.Services.Metadata;
    using Tedeschi.NFT.Util;

    public partial class MainForm : Form
    {
        private readonly ILayerService layerService;
        private readonly ICollectionService collectionService;
        private readonly IMetadataService metadataService;

        public MainForm(ILayerService layerService, ICollectionService collectionService, IMetadataService metadataService)
        {
            this.InitializeComponent();

            this.layerService = layerService;
            this.collectionService = collectionService;
            this.metadataService = metadataService;

            this.Text = $"{Application.ProductName} v{Application.ProductVersion}";
        }

        private void MainForm_OnLoad(object sender, EventArgs e)
        {
            // Folders
            this.textBoxLayersFolder.Text = Properties.Settings.Default.LayersFolder;
            this.textBoxOutputFolder.Text = Properties.Settings.Default.OutputFolder;

            // Metadata
            this.comboBoxMetadataType.SelectedIndex = Properties.Settings.Default.MetadataType;
            this.textBoxMetadataDescription.Text = Properties.Settings.Default.MetadataDescription;
            this.textBoxMetadataImageBaseURI.Text = Properties.Settings.Default.MetadataImageBaseURI;
            this.textBoxMetadataExternalUrl.Text = Properties.Settings.Default.MetadataExternalUrl;
            this.checkBoxMetadataUseFileExtension.Checked = Properties.Settings.Default.MetadataUseFileExtension;

            // Collection
            this.textBoxCollectionSize.Text = Properties.Settings.Default.CollectionSize;
            this.textBoxCollectionInitialNumber.Text = Properties.Settings.Default.CollectionInitialNumber;
            this.textBoxCollectionImagePrefix.Text = Properties.Settings.Default.CollectionImageNamePrefix;
        }

        private void MainForm_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            // Folders
            Properties.Settings.Default.LayersFolder = this.textBoxLayersFolder.Text;
            Properties.Settings.Default.OutputFolder = this.textBoxOutputFolder.Text;

            // Metadata
            Properties.Settings.Default.MetadataType = this.comboBoxMetadataType.SelectedIndex;
            Properties.Settings.Default.MetadataDescription = this.textBoxMetadataDescription.Text;
            Properties.Settings.Default.MetadataImageBaseURI = this.textBoxMetadataImageBaseURI.Text;
            Properties.Settings.Default.MetadataExternalUrl = this.textBoxMetadataExternalUrl.Text;
            Properties.Settings.Default.MetadataUseFileExtension = this.checkBoxMetadataUseFileExtension.Checked;

            // Collection
            Properties.Settings.Default.CollectionSize = this.textBoxCollectionSize.Text;
            Properties.Settings.Default.CollectionInitialNumber = this.textBoxCollectionInitialNumber.Text;
            Properties.Settings.Default.CollectionImageNamePrefix = this.textBoxCollectionImagePrefix.Text;

            Properties.Settings.Default.Save();
        }

        private void AboutMenuItemOnClick(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
        }

        private void UpdateMetadataImageBaseURIToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resource.CONFIRM_METADATA_UPDATE, Application.ProductName, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var outputFolder = this.textBoxOutputFolder.Text;
                var metadataImageBaseUri = this.textBoxMetadataImageBaseURI.Text;
                var metadataType = this.comboBoxMetadataType.SelectedIndex;
                var metadataUseFileExtension = this.checkBoxMetadataUseFileExtension.Checked;

                try
                {
                    this.ValidateForUpdateMetadata(outputFolder, metadataImageBaseUri);
                    this.metadataService.Update(outputFolder, metadataImageBaseUri, metadataType, metadataUseFileExtension);

                    MessageBox.Show(Resource.METADATA_UPDATED_SUCCESSFULLY);
                }
                catch (InvalidSettingException ex)
                {
                    MessageBox.Show(string.Format(Resource.INVALID_SETTING_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Resource.UNKNOWN_ERROR, ex), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckTraitWeightsToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            try
            {
                var layersFolder = this.textBoxLayersFolder.Text;

                this.ValidateForCheckTraitWeights(layersFolder);

                var layers = this.layerService.Load(layersFolder);

                var weightedForm = new WeightedForm();
                weightedForm.Process(layers);
                weightedForm.ShowDialog();
            }
            catch (InvalidSettingException ex)
            {
                MessageBox.Show(string.Format(Resource.INVALID_SETTING_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resource.UNKNOWN_ERROR, ex), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonLayersFolderOnClick(object sender, EventArgs e)
        {
            if (this.layersFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxLayersFolder.Text = this.layersFolderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonOutputFolderOnClick(object sender, EventArgs e)
        {
            if (this.outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxOutputFolder.Text = this.outputFolderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonGenerateOnClick(object sender, EventArgs e)
        {
            // Remove focus from others
            this.ActiveControl = null;

            var layersFolder = this.textBoxLayersFolder.Text;
            var outputFolder = this.textBoxOutputFolder.Text;

            var metadataType = this.comboBoxMetadataType.SelectedIndex;
            var metadataDescription = this.textBoxMetadataDescription.Text;
            var metadataImageBaseUri = this.textBoxMetadataImageBaseURI.Text;
            var metadataExternalUrl = this.textBoxMetadataExternalUrl.Text;
            var metadataUseFileExtension = this.checkBoxMetadataUseFileExtension.Checked;

            var collectionSize = this.textBoxCollectionSize.Text;
            var collectionInitialNumber = this.textBoxCollectionInitialNumber.Text;
            var collectionImagePrefix = this.textBoxCollectionImagePrefix.Text;

            var bgw = new BackgroundWorker();
            bgw.DoWork += (_, __) =>
            {
                try
                {
                    this.ValidateForGeneration(layersFolder, outputFolder, metadataImageBaseUri, collectionSize, collectionInitialNumber);
                    this.collectionService.CollectionItemStatus += new EventHandler<ImageEventArgs>(this.OnCollectionItemProcessed);
                    this.collectionService.Create(layersFolder, outputFolder, metadataType, metadataDescription, metadataImageBaseUri, metadataExternalUrl, metadataUseFileExtension, int.Parse(collectionSize), int.Parse(collectionInitialNumber), collectionImagePrefix);

                    MessageBox.Show(Resource.COLLECTION_CREATED_SUCCESSFULLY);
                }
                catch (InvalidSettingException ex)
                {
                    MessageBox.Show(string.Format(Resource.INVALID_SETTING_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidLayerNamingException ex)
                {
                    MessageBox.Show(string.Format(Resource.INVALID_LAYER_NAMING_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DifferentLayerSizeException ex)
                {
                    MessageBox.Show(string.Format(Resource.DIFFERENT_LAYERS_DIMENSION_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DuplicateDnaAttemptsException)
                {
                    MessageBox.Show(Resource.DUPLICATED_DNA_MAX_ATTEMPT_ERROR, Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Resource.UNKNOWN_ERROR, ex), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            bgw.RunWorkerCompleted += (_, __) =>
            {
                this.Cursor = Cursors.Default;
                ((Button)sender).Enabled = true;

                this.statusStrip.Text = string.Empty;
                this.toolStripProgressBar.Value = 0;

                this.Invoke(new Action(() =>
                {
                    this.toolStripStatus.Text = string.Empty;
                    this.toolStripProgressBar.Value = 0;
                }));

                // Remove focus from others
                this.ActiveControl = null;
            };

            this.Cursor = Cursors.WaitCursor;
            ((Button)sender).Enabled = false;

            bgw.RunWorkerAsync();
        }

        private void OnCollectionItemProcessed(object sender, ImageEventArgs e)
        {
            var status = string.Format(Resource.PROCESSING_COLLECTION_ITEM, e.CollectionItemId, this.textBoxCollectionSize.Text);

            this.Invoke(new Action(() =>
            {
                this.toolStripStatus.Text = status;

                this.toolStripProgressBar.Maximum = int.Parse(this.textBoxCollectionSize.Text);
                this.toolStripProgressBar.Value = e.CollectionItemId;
            }));
        }

        private void ValidateForGeneration(string layersFolder, string outputFolder, string imageBaseUri, string collectionSize, string collectionInitialNumber)
        {
            if (!Directory.Exists(layersFolder))
            {
                throw new InvalidSettingException("Layer folder");
            }

            if (!Directory.Exists(outputFolder))
            {
                throw new InvalidSettingException("Output folder");
            }

            if (!ValidationUtil.IsUri(imageBaseUri))
            {
                throw new InvalidSettingException("Image Base URI");
            }

            if (!ValidationUtil.IsNumeric(collectionSize) || int.Parse(collectionSize) <= 0)
            {
                throw new InvalidSettingException("Collection size");
            }

            if (!ValidationUtil.IsNumeric(collectionInitialNumber) || int.Parse(collectionInitialNumber) < 0)
            {
                throw new InvalidSettingException("Collection initial number");
            }
        }

        private void ValidateForUpdateMetadata(string outputFolder, string imageBaseUri)
        {
            if (!Directory.Exists(outputFolder))
            {
                throw new InvalidSettingException("Output folder");
            }

            if (!ValidationUtil.IsUri(imageBaseUri))
            {
                throw new InvalidSettingException("Image Base URI");
            }
        }

        private void ValidateForCheckTraitWeights(string layersFolder)
        {
            if (!Directory.Exists(layersFolder))
            {
                throw new InvalidSettingException("Layers folder");
            }
        }
    }
}
