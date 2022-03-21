using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public class PlayerInputUpdateSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<IInputService> _inputService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<PlayerInputComponent>().End();
            var playerInputComponentPool = ecsWorld.GetPool<PlayerInputComponent>();
            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref playerInputComponentPool.Get(entity);
                playerInputComponent.LeftMouseButtonStatus = _inputService.Value.LeftMouseButtonStatus;
                playerInputComponent.MousePosition = _inputService.Value.MousePosition;
            }
        }
    }
}