namespace WorldServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Protocol.WorldManager.WM2W.Api.GenerateId();
            Protocol.World.W2WM.Api.GenerateId();
        }

        void InitConfig()
        {


        }

    }
}
