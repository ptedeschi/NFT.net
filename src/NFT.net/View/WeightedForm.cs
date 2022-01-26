// <copyright file="WeightedForm.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.View
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Tedeschi.NFT.Extensions;
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
                this.richTextBoxInfo.AppendText($"{layer.Name}", Color.Black, true);
                this.richTextBoxInfo.AppendText("────────────────────────────", Color.Black, true);

                foreach (var element in layer.Elements)
                {
                    var probability = element.Weight;
                    this.richTextBoxInfo.AppendText($"\t{element.Name}: {probability}%", this.CheckRarity(element.Weight), true);
                }
            }
        }

        private Color CheckRarity(int weight)
        {
            if (weight > 70)
            {
                return Color.Green;
            }

            if (weight > 50)
            {
                return Color.Orange;
            }

            if (weight > 30)
            {
                return Color.Yellow;
            }

            if (weight > 10)
            {
                return Color.MediumVioletRed;
            }

            return Color.Red;
        }
    }
}
