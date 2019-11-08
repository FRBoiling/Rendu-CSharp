namespace Entitas.Systems.Interfaces
{
    public interface IReactiveSystem : IExecuteSystem
    {
        void Activate();
        void Deactivate();
        void Clear();
    }
}