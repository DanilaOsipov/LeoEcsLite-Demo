using Components;
using Events;
using Leopotam.EcsLite;

namespace Systems
{
    public class PointAndClickMovementFinishCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            foreach (var entity in ecsWorld.Filter<PointAndClickMovementComponent>().End())
            {
                var movementComponent = movementComponentPool.Get(entity);
                var agentPosition = movementComponent.AgentPosition;
                var destination = movementComponent.Destination;
                if (agentPosition.IsApproximate(to: destination))
                {
                    ecsWorld.GetPool<PlayerFinishMovingEvent>().Add(entity);        
                }
            }
        }
    }
}