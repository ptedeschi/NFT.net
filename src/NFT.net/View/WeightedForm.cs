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
            foreach (var layer in layers)
            {
                this.richTextBoxInfo.Text += $"\n{layer.Name}\n";
                this.richTextBoxInfo.Text += "────────────────────────────\n";

                foreach (var element in layer.Elements)
                {
                    var probability = element.Weight * 100 / layer.Randomizer.TotalWeight;
                    this.richTextBoxInfo.Text += $"\t{element.Name}: {probability}%\n";
                }
            }
        }
    }
}
