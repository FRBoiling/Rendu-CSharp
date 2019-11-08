namespace Rd.Analytics
{
    public abstract class AbstractTrackingHook : ITrackingHook
    {
        protected Tracker _tracker;

        protected virtual string host => "http://desperatedevs.com";

        protected virtual string endPoint => "a/" + name + ".php";

        protected virtual bool throwExceptions => false;

        protected abstract string name { get; }

        public void Track()
        {
            if (_tracker == null)
                _tracker = new Tracker(host, endPoint, throwExceptions);
            _tracker.Track(GetData());
        }

        protected abstract TrackingData GetData();
    }
}