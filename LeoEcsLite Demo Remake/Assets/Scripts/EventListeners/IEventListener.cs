using Leopotam.EcsLite;

namespace EventListeners
{
    public interface IEventListener
    {
        int? TryGetEntity();
        void Register(EcsWorld ecsWorld);
    }
}