// <copyright file="DifferentLayerSizeException.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Exception
{
    public class DifferentLayerSizeException : System.Exception
    {
        public DifferentLayerSizeException()
        {
        }

        public DifferentLayerSizeException(string message)
            : base(message)
        {
        }

        public DifferentLayerSizeException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
