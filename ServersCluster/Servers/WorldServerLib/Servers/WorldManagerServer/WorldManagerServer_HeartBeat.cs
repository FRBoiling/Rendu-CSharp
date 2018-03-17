using System.IO;
using Engine.Foundation;
using LogLib;
using Message.World.WorldManager.Protocol.W2WM;
using Message.WorldManager.World.Protocol.WM2W;
using ServerFrameWork;
using TcpLib;

namespace WorldServerLib
{
    public partial class WorldManagerServer
    {
        public void HeartBeat()
        {
            MSG_W2WM_HEARTBEAT requset = new MSG_W2WM_HEARTBEAT();
            requset.GroupId = _api.ApiTag.GroupId;
            requset.SubId = _api.ApiTag.SubId;
            Send(requset);
            Log.Info("HeartBeat to {0}", Tag.GetServerTagString());
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
