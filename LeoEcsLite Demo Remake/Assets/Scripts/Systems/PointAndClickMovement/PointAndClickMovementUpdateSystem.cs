using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementUpdateSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<ITimeService> _timeService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            foreach (var entity in ecsWorld.Filter<PointAndClickMovementComponent>().End())
            {
                ref var movementComponent = ref movementComponentPool.Get(entity);
                var agentPosition = movementComponent.AgentPosition;
                var destination = movementComponent.Destination;
                var speed = movementComponent.Speed;
                var direction = destination.Subtract(agentPosition).Normalized;
                movementComponent.Direction = direction;
                movementComponent.AgentPosition = agentPosition
                    .Add(direction.Multiply(speed * _timeService.Value.FixedDeltaTime));
            }
        }
    }
}