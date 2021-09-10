// <copyright file="InvalidSettingException.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Exception
{
    public class InvalidSettingException : System.Exception
    {
        public InvalidSettingException()
        {
        }

        public InvalidSettingException(string message)
            : base(message)
        {
        }

        public InvalidSettingException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
