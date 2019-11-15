namespace Entitas.Systems
{
    public interface IReactiveSystem : IExecuteSystem
    {
        void Activate();
        void Deactivate();
        void Clear();
    }
}