using Leopotam.EcsLite;

namespace Services
{
    public interface IViewService
    {
        void RegisterListeners(EcsWorld ecsWorld);
    }
}