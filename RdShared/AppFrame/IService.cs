namespace AppFrame
{
    public interface IService
    {
        void Start(string[] args);
        void Update();
        void Stop();
        void Run(string[] args);
    }
}
