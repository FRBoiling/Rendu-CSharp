using LogLib;
using Message.World.WorldManager.Protocol.W2WM;
using System.IO;

namespace WorldManagerServerLib
{
    public partial class WorldServer
    {
        private void OnResponse_HeartBeat(MemoryStream stream,int uid)
        {
            MSG_W2WM_HEARTBEAT msg = ProtoBuf.Serializer.Deserialize<MSG_W2WM_HEARTBEAT>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Log.Debug("{0} recv HeartBeat {1}",_api.ApiTag.GetServerTagString(),_tag.GetServerTagString());
        }


    }
}
