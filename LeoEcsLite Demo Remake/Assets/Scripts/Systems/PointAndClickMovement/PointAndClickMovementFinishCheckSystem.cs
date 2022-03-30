using Components;
using Events;
using Leopotam.EcsLite;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementFinishCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            var positionComponentPool = ecsWorld.GetPool<PositionComponent>();
            foreach (var entity in ecsWorld.Filter<PointAndClickMovementComponent>().Inc<PositionComponent>().End())
            {
                ref var movementComponent = ref movementComponentPool.Get(entity);
                var positionComponent = positionComponentPool.Get(entity);
                var agentPosition = positionComponent.Value;
                var destination = movementComponent.Destination;
                var stoppingDistance = movementComponent.StoppingDistance;
                if (destination == null) continue;
                if (agentPosition.Distance(to: destination) > stoppingDistance) continue;
                movementComponent.Destination = null;
                ecsWorld.GetPool<PlayerFinishMovingEvent>().Add(entity);
            }
        }
    }
}