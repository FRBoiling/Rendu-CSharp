using System;

namespace DesperateDevs.Logging
{
    public class FablAssertException : Exception
    {
        public FablAssertException(string message)
            : base(message)
        {
        }
    }
}