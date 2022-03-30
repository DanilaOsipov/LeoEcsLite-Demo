using Components;
using Leopotam.EcsLite;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementDirectingSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            var positionComponentPool = ecsWorld.GetPool<PositionComponent>();
            var directionComponentPool = ecsWorld.GetPool<DirectionComponent>();
            foreach (var entity in ecsWorld.Filter<PointAndClickMovementComponent>()
                .Inc<DirectionComponent>().Inc<PositionComponent>().End())
            {
                var destination = movementComponentPool.Get(entity).Destination;
                if (destination == null) continue;
                var position = positionComponentPool.Get(entity).Value;
                ref var directionComponent = ref directionComponentPool.Get(entity);
                directionComponent.Value = destination.Subtract(position).Normalized;  
                directionComponent.UpdateListener.OnDirectionUpdate(directionComponent.Value);
            }
        }
    }
}