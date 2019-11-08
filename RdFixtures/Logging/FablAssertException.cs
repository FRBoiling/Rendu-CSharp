using System;

namespace Rd.Logging
{
    public class FablAssertException : Exception
    {
        public FablAssertException(string message)
            : base(message)
        {
        }
    }
}