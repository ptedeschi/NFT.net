// <copyright file="MainForm.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.View
{
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Resources;
    using Tedeschi.NFT.Services.Collection;
    using Tedeschi.NFT.Services.Metadata;
    using Tedeschi.NFT.Util;

    public partial class MainForm : Form
    {
        private readonly ICollectionService collectionService;
        private readonly IMetadataService metadataService;

        public MainForm(ICollectionService collectionService, IMetadataService metadataService)
        {
            this.InitializeComponent();
            this.DefaultValues();

            this.collectionService = collectionService;
            this.metadataService = metadataService;

            this.Text = $"{Application.ProductName} v{Application.ProductVersion}";
        }

        private void DefaultValues()
        {
            this.comboBoxMetadataType.SelectedIndex = Constants.MetadataDefault.DefaultType;
            this.textBoxMetadataDescription.Text = Constants.MetadataDefault.DefaultProjectName;
            this.textBoxMetadataImageBaseURI.Text = Constants.MetadataDefault.DefaultImageBaseUri;

            this.textBoxCollectionSize.Text = Constants.CollectionDefault.DefaultSize;
            this.textBoxCollectionInitialNumber.Text = Constants.CollectionDefault.DefaultInitialNumber;
            this.textBoxCollectionImagePrefix.Text = Constants.CollectionDefault.DefaultFilenamePrefix;
        }

        private void AboutMenuItemOnClick(object sender, System.EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
        }

        private void UpdateMetadataImageBaseURIToolStripMenuItemOnClick(object sender, System.EventArgs e)
        {
            var outputFolder = this.textBoxOutputFolder.Text;
            var metadataImageBaseUri = this.textBoxMetadataImageBaseURI.Text;
            var metadataType = this.comboBoxMetadataType.SelectedIndex;

            try
            {
                this.ValidateForUpdateMetadata(outputFolder, metadataImageBaseUri);
                this.metadataService.Update(outputFolder, metadataImageBaseUri, metadataType);

                MessageBox.Show(Resource.METADATA_UPDATED_SUCCESSFULLY);
            }
            catch (InvalidSettingException ex)
            {
                MessageBox.Show(string.Format(Resource.INVALID_SETTING_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format(Resource.UNKNOWN_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonLayersFolderOnClick(object sender, System.EventArgs e)
        {
            if (this.layersFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxLayersFolder.Text = this.layersFolderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonOutputFolderOnClick(object sender, System.EventArgs e)
        {
            if (this.outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxOutputFolder.Text = this.outputFolderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonGenerateOnClick(object sender, System.EventArgs e)
        {
            // Remove focus from others
            this.ActiveControl = null;

            var layersFolder = this.textBoxLayersFolder.Text;
            var outputFolder = this.textBoxOutputFolder.Text;

            var metadataType = this.comboBoxMetadataType.SelectedIndex;
            var metadataDescription = this.textBoxMetadataDescription.Text;
            var metadataImageBaseUri = this.textBoxMetadataImageBaseURI.Text;

            var collectionSize = this.textBoxCollectionSize.Text;
            var collectionInitialNumber = this.textBoxCollectionInitialNumber.Text;
            var collectionImagePrefix = this.textBoxCollectionImagePrefix.Text;

            var bgw = new BackgroundWorker();
            bgw.DoWork += (_, __) =>
            {
                try
                {
                    this.ValidateForGeneration(layersFolder, outputFolder, metadataImageBaseUri, collectionSize, collectionInitialNumber);
                    this.collectionService.Create(layersFolder, outputFolder, metadataType, metadataDescription, metadataImageBaseUri, int.Parse(collectionSize), int.Parse(collectionInitialNumber), collectionImagePrefix);

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
                catch (System.Exception ex)
                {
                    MessageBox.Show(string.Format(Resource.UNKNOWN_ERROR, ex.Message), Resource.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            bgw.RunWorkerCompleted += (_, __) =>
            {
                this.Cursor = Cursors.Default;
                ((Button)sender).Enabled = true;

                // Remove focus from others
                this.ActiveControl = null;
            };

            this.Cursor = Cursors.WaitCursor;
            ((Button)sender).Enabled = false;

            bgw.RunWorkerAsync();
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
    }
}
