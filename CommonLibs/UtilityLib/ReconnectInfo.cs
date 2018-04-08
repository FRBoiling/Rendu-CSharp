namespace UtilityLib
{
    public class ReconnectRecord
    {
        public double TryConnectTime = 0.0;
        public double MaxConnectTime;
        public bool NeedReconnect = false;
        public void Init(double max_connect_time)
        {
            TryConnectTime = 0.0;
            MaxConnectTime = max_connect_time;
            NeedReconnect = false;
        }

        public void Reset()
        {
            TryConnectTime = 0.0;
            NeedReconnect = false;
        }
    }
}
