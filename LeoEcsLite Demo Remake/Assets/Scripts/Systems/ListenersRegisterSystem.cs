using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public class ListenersRegisterSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<IViewService> _viewService;
        
        public void Init(EcsSystems systems) => _viewService.Value.RegisterListeners(systems.GetWorld());
    }
}