
namespace Tedeschi.NFT.View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonLayersFolder = new System.Windows.Forms.Button();
            this.textBoxLayersFolder = new System.Windows.Forms.TextBox();
            this.textBoxOutputFolder = new System.Windows.Forms.TextBox();
            this.buttonOutputFolder = new System.Windows.Forms.Button();
            this.layersFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCollectionSize = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCollectionImagePrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCollectionInitialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMetadataType = new System.Windows.Forms.ComboBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxMetadataUseFileExtension = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMetadataExternalUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMetadataImageBaseURI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMetadataDescription = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkTraitWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMetadataImageBaseURIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLayersFolder
            // 
            this.buttonLayersFolder.Location = new System.Drawing.Point(365, 85);
            this.buttonLayersFolder.Name = "buttonLayersFolder";
            this.buttonLayersFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonLayersFolder.TabIndex = 2;
            this.buttonLayersFolder.Text = "Layers...";
            this.buttonLayersFolder.UseVisualStyleBackColor = true;
            this.buttonLayersFolder.Click += new System.EventHandler(this.ButtonLayersFolderOnClick);
            // 
            // textBoxLayersFolder
            // 
            this.textBoxLayersFolder.Location = new System.Drawing.Point(36, 85);
            this.textBoxLayersFolder.Name = "textBoxLayersFolder";
            this.textBoxLayersFolder.Size = new System.Drawing.Size(323, 23);
            this.textBoxLayersFolder.TabIndex = 1;
            // 
            // textBoxOutputFolder
            // 
            this.textBoxOutputFolder.Location = new System.Drawing.Point(36, 125);
            this.textBoxOutputFolder.Name = "textBoxOutputFolder";
            this.textBoxOutputFolder.Size = new System.Drawing.Size(323, 23);
            this.textBoxOutputFolder.TabIndex = 3;
            // 
            // buttonOutputFolder
            // 
            this.buttonOutputFolder.Location = new System.Drawing.Point(365, 125);
            this.buttonOutputFolder.Name = "buttonOutputFolder";
            this.buttonOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOutputFolder.TabIndex = 4;
            this.buttonOutputFolder.Text = "Output...";
            this.buttonOutputFolder.UseVisualStyleBackColor = true;
            this.buttonOutputFolder.Click += new System.EventHandler(this.ButtonOutputFolderOnClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // textBoxCollectionSize
            // 
            this.textBoxCollectionSize.Location = new System.Drawing.Point(118, 28);
            this.textBoxCollectionSize.Name = "textBoxCollectionSize";
            this.textBoxCollectionSize.Size = new System.Drawing.Size(121, 23);
            this.textBoxCollectionSize.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCollectionImagePrefix);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxCollectionInitialNumber);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxCollectionSize);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 123);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Collection";
            // 
            // textBoxCollectionImagePrefix
            // 
            this.textBoxCollectionImagePrefix.Location = new System.Drawing.Point(118, 86);
            this.textBoxCollectionImagePrefix.Name = "textBoxCollectionImagePrefix";
            this.textBoxCollectionImagePrefix.Size = new System.Drawing.Size(121, 23);
            this.textBoxCollectionImagePrefix.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Image Prefix";
            // 
            // textBoxCollectionInitialNumber
            // 
            this.textBoxCollectionInitialNumber.Location = new System.Drawing.Point(118, 57);
            this.textBoxCollectionInitialNumber.Name = "textBoxCollectionInitialNumber";
            this.textBoxCollectionInitialNumber.Size = new System.Drawing.Size(121, 23);
            this.textBoxCollectionInitialNumber.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Initial Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Type";
            // 
            // comboBoxMetadataType
            // 
            this.comboBoxMetadataType.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxMetadataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMetadataType.FormattingEnabled = true;
            this.comboBoxMetadataType.Items.AddRange(new object[] {
            "None",
            "Merged",
            "Individual",
            "Both"});
            this.comboBoxMetadataType.Location = new System.Drawing.Point(142, 20);
            this.comboBoxMetadataType.Name = "comboBoxMetadataType";
            this.comboBoxMetadataType.Size = new System.Drawing.Size(121, 23);
            this.comboBoxMetadataType.TabIndex = 6;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(12, 480);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(465, 28);
            this.buttonGenerate.TabIndex = 13;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateOnClick);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(131, 231);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 23);
            this.textBox1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxMetadataUseFileExtension);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxMetadataExternalUrl);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxMetadataImageBaseURI);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxMetadataDescription);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxMetadataType);
            this.groupBox3.Location = new System.Drawing.Point(12, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 144);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Metadata";
            // 
            // checkBoxMetadataUseExtension
            // 
            this.checkBoxMetadataUseFileExtension.AutoSize = true;
            this.checkBoxMetadataUseFileExtension.Location = new System.Drawing.Point(384, 21);
            this.checkBoxMetadataUseFileExtension.Name = "checkBoxMetadataUseExtension";
            this.checkBoxMetadataUseFileExtension.Size = new System.Drawing.Size(73, 19);
            this.checkBoxMetadataUseFileExtension.TabIndex = 20;
            this.checkBoxMetadataUseFileExtension.Text = "Use .json";
            this.checkBoxMetadataUseFileExtension.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "External URL";
            // 
            // textBoxMetadataExternalUrl
            // 
            this.textBoxMetadataExternalUrl.Location = new System.Drawing.Point(142, 108);
            this.textBoxMetadataExternalUrl.Name = "textBoxMetadataExternalUrl";
            this.textBoxMetadataExternalUrl.Size = new System.Drawing.Size(317, 23);
            this.textBoxMetadataExternalUrl.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Image Base URI";
            // 
            // textBoxMetadataImageBaseURI
            // 
            this.textBoxMetadataImageBaseURI.Location = new System.Drawing.Point(142, 78);
            this.textBoxMetadataImageBaseURI.Name = "textBoxMetadataImageBaseURI";
            this.textBoxMetadataImageBaseURI.Size = new System.Drawing.Size(317, 23);
            this.textBoxMetadataImageBaseURI.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Description";
            // 
            // textBoxMetadataDescription
            // 
            this.textBoxMetadataDescription.Location = new System.Drawing.Point(142, 49);
            this.textBoxMetadataDescription.Name = "textBoxMetadataDescription";
            this.textBoxMetadataDescription.Size = new System.Drawing.Size(317, 23);
            this.textBoxMetadataDescription.TabIndex = 7;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 515);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(490, 22);
            this.statusStrip.TabIndex = 10;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(490, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkTraitWeightsToolStripMenuItem,
            this.updateMetadataImageBaseURIToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // checkTraitWeightsToolStripMenuItem
            // 
            this.checkTraitWeightsToolStripMenuItem.Name = "checkTraitWeightsToolStripMenuItem";
            this.checkTraitWeightsToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.checkTraitWeightsToolStripMenuItem.Text = "Check Trait Weights";
            this.checkTraitWeightsToolStripMenuItem.Click += new System.EventHandler(this.CheckTraitWeightsToolStripMenuItemOnClick);
            // 
            // updateMetadataImageBaseURIToolStripMenuItem
            // 
            this.updateMetadataImageBaseURIToolStripMenuItem.Name = "updateMetadataImageBaseURIToolStripMenuItem";
            this.updateMetadataImageBaseURIToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.updateMetadataImageBaseURIToolStripMenuItem.Text = "Update Metadata Image Base URI";
            this.updateMetadataImageBaseURIToolStripMenuItem.Click += new System.EventHandler(this.UpdateMetadataImageBaseURIToolStripMenuItemOnClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutMenuItemOnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 537);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.textBoxOutputFolder);
            this.Controls.Add(this.buttonOutputFolder);
            this.Controls.Add(this.textBoxLayersFolder);
            this.Controls.Add(this.buttonLayersFolder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 576);
            this.MinimumSize = new System.Drawing.Size(506, 576);
            this.Name = "MainForm";
            this.Text = "NFT.net";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_OnFormClosed);
            this.Load += new System.EventHandler(this.MainForm_OnLoad);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLayersFolder;
        private System.Windows.Forms.TextBox textBoxLayersFolder;
        private System.Windows.Forms.TextBox textBoxOutputFolder;
        private System.Windows.Forms.Button buttonOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog layersFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog outputFolderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCollectionSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxCollectionImagePrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCollectionInitialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMetadataType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMetadataImageBaseURI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMetadataDescription;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMetadataImageBaseURIToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem checkTraitWeightsToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMetadataExternalUrl;
        private System.Windows.Forms.CheckBox checkBoxMetadataUseFileExtension;
    }
}
