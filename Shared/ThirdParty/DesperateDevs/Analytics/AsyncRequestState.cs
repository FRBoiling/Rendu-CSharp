using System;
using System.Net;

namespace DesperateDevs.Analytics
{
    internal class AsyncRequestState
    {
        public readonly HttpWebRequest request;
        public readonly Action onComplete;

        public AsyncRequestState(HttpWebRequest request, Action onComplete)
        {
            this.request = request;
            this.onComplete = onComplete;
        }
    }
}