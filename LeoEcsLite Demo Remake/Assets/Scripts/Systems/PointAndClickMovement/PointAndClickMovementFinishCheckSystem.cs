using Components;
using Events;
using Leopotam.EcsLite;
using Other;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementFinishCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            var positionComponentPool = ecsWorld.GetPool<PositionComponent>();
            var obstacleHitPool = ecsWorld.GetPool<ObstacleHitEvent>();
            foreach (var entity in ecsWorld.Filter<PointAndClickMovementComponent>().Inc<PositionComponent>().End())
            {
                ref var movementComponent = ref movementComponentPool.Get(entity);
                var positionComponent = positionComponentPool.Get(entity);
                var agentPosition = positionComponent.Value;
                var destination = movementComponent.Destination;
                var stoppingDistance = movementComponent.StoppingDistance;
                if (destination == null) continue;
                if (!CheckDestination(agentPosition, destination, stoppingDistance)
                    && !CheckObstacle(obstacleHitPool, entity)) continue;
                movementComponent.Destination = null;
                ecsWorld.GetPool<PlayerFinishMovingEvent>().Add(entity);
            }
        }

        private bool CheckObstacle(EcsPool<ObstacleHitEvent> obstacleHitPool, int entity)
            => obstacleHitPool.Has(entity);

        private bool CheckDestination(IVector agentPosition, IVector destination, float stoppingDistance)
            => agentPosition.Distance(to: destination) < stoppingDistance;
    }
}