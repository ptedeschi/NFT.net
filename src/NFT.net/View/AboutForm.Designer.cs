
namespace Tedeschi.NFT.View
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelDevelopedBy = new System.Windows.Forms.Label();
            this.labelSite = new System.Windows.Forms.Label();
            this.linkLabelSiteUrl = new System.Windows.Forms.LinkLabel();
            this.labelWalletAddress = new System.Windows.Forms.Label();
            this.labelWalletInfo = new System.Windows.Forms.Label();
            this.buttonCopyWalletAddress = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tedeschi.NFT.Resources.Resource.logo;
            this.pictureBox1.Location = new System.Drawing.Point(43, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(216, 39);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 15);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "<app>";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(231, 205);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(72, 24);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkOnClick);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVersion.Location = new System.Drawing.Point(263, 39);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 15);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "<version>";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDevelopedBy
            // 
            this.labelDevelopedBy.AutoSize = true;
            this.labelDevelopedBy.Location = new System.Drawing.Point(216, 60);
            this.labelDevelopedBy.Name = "labelDevelopedBy";
            this.labelDevelopedBy.Size = new System.Drawing.Size(94, 15);
            this.labelDevelopedBy.TabIndex = 4;
            this.labelDevelopedBy.Text = "<developed by>";
            // 
            // labelSite
            // 
            this.labelSite.AutoSize = true;
            this.labelSite.Location = new System.Drawing.Point(216, 97);
            this.labelSite.Name = "labelSite";
            this.labelSite.Size = new System.Drawing.Size(0, 15);
            this.labelSite.TabIndex = 5;
            // 
            // linkLabelSiteUrl
            // 
            this.linkLabelSiteUrl.AutoSize = true;
            this.linkLabelSiteUrl.Location = new System.Drawing.Point(216, 80);
            this.linkLabelSiteUrl.Name = "linkLabelSiteUrl";
            this.linkLabelSiteUrl.Size = new System.Drawing.Size(94, 15);
            this.linkLabelSiteUrl.TabIndex = 6;
            this.linkLabelSiteUrl.TabStop = true;
            this.linkLabelSiteUrl.Text = "<developed by>";
            this.linkLabelSiteUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSiteUrlOnClicked);
            // 
            // labelWalletAddress
            // 
            this.labelWalletAddress.AutoSize = true;
            this.labelWalletAddress.Location = new System.Drawing.Point(216, 164);
            this.labelWalletAddress.Name = "labelWalletAddress";
            this.labelWalletAddress.Size = new System.Drawing.Size(99, 15);
            this.labelWalletAddress.TabIndex = 7;
            this.labelWalletAddress.Text = "<wallet_address>";
            // 
            // labelWalletInfo
            // 
            this.labelWalletInfo.AutoSize = true;
            this.labelWalletInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWalletInfo.Location = new System.Drawing.Point(216, 145);
            this.labelWalletInfo.Name = "labelWalletInfo";
            this.labelWalletInfo.Size = new System.Drawing.Size(143, 15);
            this.labelWalletInfo.TabIndex = 8;
            this.labelWalletInfo.Text = "<Wallet for donnations>";
            // 
            // buttonCopyWalletAddress
            // 
            this.buttonCopyWalletAddress.BackgroundImage = global::Tedeschi.NFT.Resources.Resource.copy;
            this.buttonCopyWalletAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyWalletAddress.Location = new System.Drawing.Point(488, 150);
            this.buttonCopyWalletAddress.Name = "buttonCopyWalletAddress";
            this.buttonCopyWalletAddress.Size = new System.Drawing.Size(41, 32);
            this.buttonCopyWalletAddress.TabIndex = 9;
            this.buttonCopyWalletAddress.UseVisualStyleBackColor = true;
            this.buttonCopyWalletAddress.Click += new System.EventHandler(this.ButtonCopyWalletAddressOnClick);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(536, 259);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCopyWalletAddress);
            this.Controls.Add(this.labelWalletInfo);
            this.Controls.Add(this.labelWalletAddress);
            this.Controls.Add(this.linkLabelSiteUrl);
            this.Controls.Add(this.labelSite);
            this.Controls.Add(this.labelDevelopedBy);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDevelopedBy;
        private System.Windows.Forms.Label labelSite;
        private System.Windows.Forms.LinkLabel linkLabelSiteUrl;
        private System.Windows.Forms.Label labelWalletAddress;
        private System.Windows.Forms.Label labelWalletInfo;
        private System.Windows.Forms.Button buttonCopyWalletAddress;
    }
}