// <copyright file="RichTextBoxExtension.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Extensions
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public static class RichTextBoxExtension
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            if (addNewLine)
            {
                text += Environment.NewLine;
            }

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
