// <copyright file="AboutForm.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.View
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Tedeschi.NFT.Resources;

    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            this.InitializeComponent();

            this.labelName.Text = Application.ProductName;
            this.labelVersion.Text = Application.ProductVersion;
            this.labelDevelopedBy.Text = string.Format(Resource.DEVELOPED_BY, Application.CompanyName);

            this.linkLabelSiteUrl.Text = Constants.About.SiteUrl;
            this.labelWalletInfo.Text = string.Format(Resource.WALLET_FOR_DONATION_INFO, Constants.About.WalletNetwork);
            this.labelWalletAddress.Text = Constants.About.WalletAddress;
        }

        private void ButtonOkOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCopyWalletAddressOnClick(object sender, EventArgs e)
        {
            Clipboard.SetText(Constants.About.WalletAddress);

            MessageBox.Show(string.Format(Resource.WALLET_ADDRESS_COPIED, Constants.About.WalletNetwork));
        }

        private void LinkLabelSiteUrlOnClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var psInfo = new ProcessStartInfo
            {
                FileName = Constants.About.SiteUrl,
                UseShellExecute = true,
            };

            Process.Start(psInfo);
        }
    }
}
