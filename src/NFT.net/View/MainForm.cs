// <copyright file="MainForm.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.View
{
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Tedeschi.NFT.Exception;
    using Tedeschi.NFT.Helper;
    using Tedeschi.NFT.Resources;
    using Tedeschi.NFT.Util;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
            this.DefaultValues();
        }

        private void DefaultValues()
        {
            this.comboBoxMetadataType.SelectedIndex = Constants.MetadataDefault.DefaultType;
            this.textBoxMetadataProjectName.Text = Constants.MetadataDefault.DefaultProjectName;
            this.textBoxMetadataImageBaseURI.Text = Constants.MetadataDefault.DefaultImageBaseUri;

            this.textBoxCollectionSize.Text = Constants.CollectionDefault.DefaultSize;
            this.textBoxCollectionInitialNumber.Text = Constants.CollectionDefault.DefaultInitialNumber;
            this.textBoxCollectionFilenamePrefix.Text = Constants.CollectionDefault.DefaultFilenamePrefix;
        }

        private void AboutMenuItemOnClick(object sender, System.EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
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
            var metadataProjectName = this.textBoxMetadataProjectName.Text;
            var metadataImageBaseUri = this.textBoxMetadataImageBaseURI.Text;

            var collectionSize = this.textBoxCollectionSize.Text;
            var collectionInitialNumber = this.textBoxCollectionInitialNumber.Text;
            var collectionFilenamePrefix = this.textBoxCollectionFilenamePrefix.Text;

            var bgw = new BackgroundWorker();
            bgw.DoWork += (_, __) =>
            {
                try
                {
                    this.ValidateInput(layersFolder, outputFolder, metadataImageBaseUri, collectionSize, collectionInitialNumber);
                    CollectionHelper.Create(layersFolder, outputFolder, metadataType, metadataProjectName, metadataImageBaseUri, int.Parse(collectionSize), int.Parse(collectionInitialNumber), collectionFilenamePrefix);

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

        private void ValidateInput(string layersFolder, string outputFolder, string imageBaseUri, string collectionSize, string collectionInitialNumber)
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
    }
}
