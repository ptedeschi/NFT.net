// <copyright file="InvalidLayerNamingException.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Exception
{
    public class InvalidLayerNamingException : System.Exception
    {
        public InvalidLayerNamingException()
        {
        }

        public InvalidLayerNamingException(string message)
            : base(message)
        {
        }

        public InvalidLayerNamingException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
