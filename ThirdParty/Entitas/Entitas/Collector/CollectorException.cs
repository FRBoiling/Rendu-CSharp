namespace Entitas.Collector
{
    public class CollectorException : EntitasException
    {
        public CollectorException(string message, string hint)
            : base(message, hint)
        {
        }
    }
}