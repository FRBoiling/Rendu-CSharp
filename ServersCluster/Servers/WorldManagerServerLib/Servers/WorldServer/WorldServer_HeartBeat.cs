using LogLib;
using Protocol.World.W2WM;
using System.IO;

namespace WorldManagerServerLib
{
    public partial class WorldServer
    {
        private void OnResponse_Heartbeat(MemoryStream stream,int uid)
        {
            MSG_W2WM_Heartbeat msg = ProtoBuf.Serializer.Deserialize<MSG_W2WM_Heartbeat>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Log.Debug("{0} recv Heartbeat {1}",_api.ApiTag.GetServerTagString(),_tag.GetServerTagString());
        }


    }
}
