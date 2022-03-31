using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<IPhysicsService> _physicsService;
        private readonly EcsCustomInject<IVectorService> _vectorService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var groundCheckerPool = ecsWorld.GetPool<GroundCheckerComponent>();
            var positionPool = ecsWorld.GetPool<PositionComponent>();
            foreach (var entity in ecsWorld.Filter<GroundCheckerComponent>().Inc<PositionComponent>().End())
                CheckGround(groundCheckerPool.Get(entity), positionPool.Get(entity), ecsWorld);
        }

        private void CheckGround(GroundCheckerComponent checkerComponent, PositionComponent positionComponent,
            EcsWorld ecsWorld)
        {
            var position = positionComponent.Value.Copy;
            position.Y += checkerComponent.YOffset;
            if (!_physicsService.Value.CastRay(position, _vectorService.Value.DownVector, 
                checkerComponent.CheckDistance, out var hitInfo)) return;
            var hitEventPool = ecsWorld.GetPool<GroundHitEvent>();
            ref var hitEvent = ref hitEventPool.Add(ecsWorld.NewEntity());
            hitEvent.HitInfo = hitInfo;
        }
    }
}