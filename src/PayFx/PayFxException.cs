using System;

namespace PayFx
{
    public class PayFxException : Exception
    {
        public PayFxException(string message)
            : base(message) { }
    }
}
