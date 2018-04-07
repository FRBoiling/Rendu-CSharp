using System.IO;
using LogLib;
using Protocol.World.W2WM;
using Protocol.WorldManager.WM2W;

namespace WorldServerLib
{
    public partial class WorldManagerServer
    {
        public void Heartbeat()
        {
            MSG_W2WM_Heartbeat requset = new MSG_W2WM_Heartbeat();
            requset.GroupId = _api.ApiTag.GroupId;
            requset.SubId = _api.ApiTag.SubId;
            Send(requset);
            Log.Info("Heartbeat to {0}", Tag.GetServerTagString());
        }

        private void OnResponse_HeartBeat(MemoryStream stream, int uid)
        {
            MSG_WM2W_HEARTBEAT msg = ProtoBuf.Serializer.Deserialize<MSG_WM2W_HEARTBEAT>(stream);
            //Tag.GroupId = (ushort)msg.GroupId;
            //Tag.SubId = (ushort)msg.SubId;
            //Tag.Ip = Ip;
            //Tag.Port = Port;
            //Log.Info("registed success to {0}", Tag.GetServerTagString());
        }
    }
}
