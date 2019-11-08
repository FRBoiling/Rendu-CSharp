namespace Entitas.EntityIndex
{
    public class EntityIndexException : EntitasException
    {
        public EntityIndexException(string message, string hint)
            : base(message, hint)
        {
        }
    }
}