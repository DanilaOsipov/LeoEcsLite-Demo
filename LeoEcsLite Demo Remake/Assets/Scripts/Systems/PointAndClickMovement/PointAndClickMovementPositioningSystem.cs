using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Other;
using Services;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementPositioningSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<ITimeService> _timeService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            var positionComponentPool = ecsWorld.GetPool<PositionComponent>();
            foreach (var entity in ecsWorld.Filter<PointAndClickMovementComponent>().Inc<PositionComponent>().End())
            {
                var movementComponent = movementComponentPool.Get(entity);
                if (movementComponent.Destination == null) continue;
                ref var positionComponent = ref positionComponentPool.Get(entity);
                var destination = movementComponent.Destination;
                var curPosition = positionComponent.Value;
                var speed = movementComponent.Speed;
                positionComponent.Value = CalculatePosition(destination, curPosition, speed);
                positionComponent.UpdateListener.OnPositionUpdate(positionComponent.Value);
            }
        }

        private IVector CalculatePosition(IVector destination, IVector curPosition, float speed)
        {
            var direction = destination.Subtract(curPosition).Normalized;
            return curPosition.Add(direction.Multiply(speed * _timeService.Value.FixedDeltaTime));
        }
    }
}