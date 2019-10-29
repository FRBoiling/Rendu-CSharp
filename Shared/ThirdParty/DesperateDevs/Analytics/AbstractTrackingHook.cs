namespace DesperateDevs.Analytics
{
    public abstract class AbstractTrackingHook : ITrackingHook
    {
        protected Tracker _tracker;

        protected virtual string host
        {
            get
            {
                return "http://desperatedevs.com";
            }
        }

        protected virtual string endPoint
        {
            get
            {
                return "a/" + this.name + ".php";
            }
        }

        protected virtual bool throwExceptions
        {
            get
            {
                return false;
            }
        }

        protected abstract string name { get; }

        public void Track()
        {
            if (this._tracker == null)
                this._tracker = new Tracker(this.host, this.endPoint, this.throwExceptions);
            this._tracker.Track(this.GetData());
        }

        protected abstract TrackingData GetData();
    }
}