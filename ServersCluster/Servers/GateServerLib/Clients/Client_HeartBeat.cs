using LogLib;
using Protocol.Client.C2G;
using System.IO;

namespace GateServerLib
{
    public partial class Client
    {

        private void OnResponse_HeartBeat(MemoryStream stream, int uid)
        {
            MSG_C2G_Heartbeat msg = ProtoBuf.Serializer.Deserialize<MSG_C2G_Heartbeat>(stream);
            Log.Debug("recv heart beat {0}",_tag.Ip);
            //Tag.GroupId = (ushort)msg.GroupId;
            //Tag.SubId = (ushort)msg.SubId;
            //Tag.Ip = Ip;
            //Tag.Port = Port;
            //Log.Info("registed success to {0}", Tag.GetServerTagString());
        }


    }
}
