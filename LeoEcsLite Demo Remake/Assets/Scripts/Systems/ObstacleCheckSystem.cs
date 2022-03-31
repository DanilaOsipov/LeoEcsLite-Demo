using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public class ObstacleCheckSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<IPhysicsService> _physicsService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var positionPool = ecsWorld.GetPool<PositionComponent>();
            var directionPool = ecsWorld.GetPool<DirectionComponent>();
            var obstacleCheckerPool = ecsWorld.GetPool<ObstacleCheckerComponent>();
            var obstacleHitPool = ecsWorld.GetPool<ObstacleHitEvent>();
            foreach (var entity in ecsWorld.Filter<ObstacleCheckerComponent>()
                .Inc<DirectionComponent>().Inc<PositionComponent>().End())
            {
                var checkerComponent = obstacleCheckerPool.Get(entity);
                var checkDistance = checkerComponent.CheckDistance;
                var position = positionPool.Get(entity).Value.Copy;
                position.Y += checkerComponent.YOffset;
                var direction = directionPool.Get(entity).Value;
                if (!_physicsService.Value.CastRay(position, direction, checkDistance, out var hitInfo)) continue;
                ref var obstacleHitEvent = ref obstacleHitPool.Add(entity);
                obstacleHitEvent.HitInfo = hitInfo;
            }
        }
    }
}