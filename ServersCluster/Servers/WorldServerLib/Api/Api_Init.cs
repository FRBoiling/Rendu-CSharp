namespace WorldServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Message.WorldManager.World.Protocol.WM2W.Api.GenerateId();
            Message.World.WorldManager.Protocol.W2WM.Api.GenerateId();
        }

      
      
    }
}
