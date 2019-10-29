using DesperateDevs.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DesperateDevs.Analytics
{
  public class Tracker
  {
    private readonly Logger _logger = fabl.GetLogger(typeof (Tracker));
    private readonly string _url;
    private readonly bool _throwExceptions;

    public Tracker(string host, string endPoint, bool throwExceptions)
    {
      this._url = host + "/" + endPoint;
      this._throwExceptions = throwExceptions;
    }

    public virtual void Track(TrackingData data)
    {
      if (this._throwExceptions)
      {
        this.getResponse(data);
      }
      else
      {
        try
        {
          this.getResponse(data);
        }
        catch (Exception ex)
        {
        }
      }
    }

    public virtual void TrackAsync(TrackingData data, Action onComplete)
    {
      if (this._throwExceptions)
      {
        this.getResponseAsync(data, onComplete);
      }
      else
      {
        try
        {
          this.getResponseAsync(data, onComplete);
        }
        catch (Exception ex)
        {
        }
      }
    }

    private HttpWebRequest createWebRequest(TrackingData data)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(this.buildTrackingCall(data));
      httpWebRequest.Timeout = 3000;
      return httpWebRequest;
    }

    private void getResponse(TrackingData data)
    {
      this.createWebRequest(data).GetResponse().Close();
    }

    private void getResponseAsync(TrackingData data, Action onComplete)
    {
      HttpWebRequest webRequest = this.createWebRequest(data);
      webRequest.BeginGetResponse(new AsyncCallback(this.onResponse), (object) new AsyncRequestState(webRequest, onComplete));
    }

    private void onResponse(IAsyncResult ar)
    {
      if (this._throwExceptions)
      {
        this.endResponse(ar);
      }
      else
      {
        try
        {
          this.endResponse(ar);
        }
        catch (Exception ex)
        {
        }
      }
    }

    private void endResponse(IAsyncResult ar)
    {
      AsyncRequestState asyncState = (AsyncRequestState) ar.AsyncState;
      asyncState.request.EndGetResponse(ar).Close();
      if (asyncState.onComplete == null)
        return;
      asyncState.onComplete();
    }

    protected string buildTrackingCall(TrackingData data)
    {
      string message = data.Count != 0 ? this._url + Uri.EscapeUriString("?" + string.Join("&", data.Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (kv => kv.Key + "=" + kv.Value)).ToArray<string>())) : this._url;
      this._logger.Trace(message);
      return message;
    }
  }
}