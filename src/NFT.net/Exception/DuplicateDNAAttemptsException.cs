// <copyright file="DuplicateDNAAttemptsException.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>

namespace Tedeschi.NFT.Exception
{
    public class DuplicateDnaAttemptsException : System.Exception
    {
        public DuplicateDnaAttemptsException()
        {
        }

        public DuplicateDnaAttemptsException(string message)
            : base(message)
        {
        }

        public DuplicateDnaAttemptsException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
