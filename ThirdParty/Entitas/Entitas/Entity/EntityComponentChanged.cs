namespace Entitas.Entity
{
    public delegate void EntityComponentChanged(
        IEntity entity, int index, IComponent component
    );
}