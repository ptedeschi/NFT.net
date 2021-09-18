// <copyright file="ImageService.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Services.Image
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Tedeschi.NFT.Exception;

    internal class ImageService : IImageService
    {
        public Bitmap Combine(string[] files)
        {
            var images = new List<Bitmap>();
            Bitmap baseImage = null;

            try
            {
                // Create a bitmap from first image to obtain the desired dimensions
                var tempBitmap = new Bitmap(files[0]);
                var width = tempBitmap.Width;
                var height = tempBitmap.Height;

                // Disposing tempBitmap
                tempBitmap?.Dispose();

                baseImage = new Bitmap(width, height);

                foreach (var image in files)
                {
                    var bitmap = new Bitmap(image);

                    // If image size differ from the base, abort process
                    if (bitmap.Width != width ||
                        bitmap.Height != height)
                    {
                        throw new DifferentLayerSizeException(image);
                    }

                    images.Add(bitmap);
                }

                using var graphics = Graphics.FromImage(baseImage);
                foreach (var image in images)
                {
                    // Draw the image with no shrinking or stretching
                    graphics.DrawImage(
                        image,
                        new Rectangle(0, 0, width, height),
                        0,
                        0,
                        width,
                        height,
                        GraphicsUnit.Pixel,
                        null);
                }

                return baseImage;
            }
            catch (Exception)
            {
                baseImage?.Dispose();

                throw;
            }
            finally
            {
                foreach (var image in images)
                {
                    image.Dispose();
                }
            }
        }
    }
}
