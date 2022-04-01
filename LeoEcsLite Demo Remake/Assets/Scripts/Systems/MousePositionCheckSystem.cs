using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public class MousePositionCheckSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<IPhysicsService> _physicsService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var playerInputComponentPool = ecsWorld.GetPool<PlayerInputComponent>();
            foreach (var entity in ecsWorld.Filter<PlayerInputComponent>().End())
            {
                var mousePosition = playerInputComponentPool.Get(entity).MousePosition;
                if (!_physicsService.Value.CastRayFromScreenPoint(mousePosition, out var hitInfo)) continue;
                var mouseHitPool = ecsWorld.GetPool<MouseHitEvent>();
                ref var mouseHitComponent =  ref mouseHitPool.Add(ecsWorld.NewEntity());
                mouseHitComponent.HitInfo = hitInfo;
            }
        }
    }
}