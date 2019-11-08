using System;
using System.Net;

namespace Rd.Analytics
{
    internal class AsyncRequestState
    {
        public readonly Action onComplete;
        public readonly HttpWebRequest request;

        public AsyncRequestState(HttpWebRequest request, Action onComplete)
        {
            this.request = request;
            this.onComplete = onComplete;
        }
    }
}