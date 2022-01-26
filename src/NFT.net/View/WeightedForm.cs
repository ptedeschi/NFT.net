// <copyright file="WeightedForm.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.View
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Tedeschi.NFT.Model;

    public partial class WeightedForm : Form
    {
        public WeightedForm()
        {
            this.InitializeComponent();
        }

        public void Process(List<Layer> layers)
        {
            this.richTextBoxInfo.Text = "To be removed in future versions";
        }
    }
}
