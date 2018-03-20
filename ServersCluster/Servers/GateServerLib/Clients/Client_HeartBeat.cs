using LogLib;
using Message.Client.Gate.Protocol.CG;
using System.IO;
using TcpLib;

namespace GateServerLib
{
    public partial class Client
    {

        private void OnResponse_HeartBeat(MemoryStream stream, int uid)
        {
            MSG_C2G_HEARTBEAT msg = ProtoBuf.Serializer.Deserialize<MSG_C2G_HEARTBEAT>(stream);
            Log.Debug("recv heart beat {0}",_tag.Ip);
            //Tag.GroupId = (ushort)msg.GroupId;
            //Tag.SubId = (ushort)msg.SubId;
            //Tag.Ip = Ip;
            //Tag.Port = Port;
            //Log.Info("registed success to {0}", Tag.GetServerTagString());
        }


    }
}
