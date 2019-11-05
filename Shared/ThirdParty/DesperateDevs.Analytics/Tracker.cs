using System;
using System.Linq;
using System.Net;
using DesperateDevs.Logging;

namespace DesperateDevs.Analytics
{
    public class Tracker
    {
        private readonly Logger _logger = fabl.GetLogger(typeof(Tracker));
        private readonly bool _throwExceptions;
        private readonly string _url;

        public Tracker(string host, string endPoint, bool throwExceptions)
        {
            _url = host + "/" + endPoint;
            _throwExceptions = throwExceptions;
        }

        public virtual void Track(TrackingData data)
        {
            if (_throwExceptions)
                getResponse(data);
            else
                try
                {
                    getResponse(data);
                }
                catch (Exception ex)
                {
                }
        }

        public virtual void TrackAsync(TrackingData data, Action onComplete)
        {
            if (_throwExceptions)
                getResponseAsync(data, onComplete);
            else
                try
                {
                    getResponseAsync(data, onComplete);
                }
                catch (Exception ex)
                {
                }
        }

        private HttpWebRequest createWebRequest(TrackingData data)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(buildTrackingCall(data));
            httpWebRequest.Timeout = 3000;
            return httpWebRequest;
        }

        private void getResponse(TrackingData data)
        {
            createWebRequest(data).GetResponse().Close();
        }

        private void getResponseAsync(TrackingData data, Action onComplete)
        {
            var webRequest = createWebRequest(data);
            webRequest.BeginGetResponse(onResponse, new AsyncRequestState(webRequest, onComplete));
        }

        private void onResponse(IAsyncResult ar)
        {
            if (_throwExceptions)
                endResponse(ar);
            else
                try
                {
                    endResponse(ar);
                }
                catch (Exception ex)
                {
                }
        }

        private void endResponse(IAsyncResult ar)
        {
            var asyncState = (AsyncRequestState) ar.AsyncState;
            asyncState.request.EndGetResponse(ar).Close();
            if (asyncState.onComplete == null)
                return;
            asyncState.onComplete();
        }

        protected string buildTrackingCall(TrackingData data)
        {
            var message = data.Count != 0 ? _url + Uri.EscapeUriString("?" + string.Join("&", data.Select(kv => kv.Key + "=" + kv.Value).ToArray())) : _url;
            _logger.Trace(message);
            return message;
        }
    }
}