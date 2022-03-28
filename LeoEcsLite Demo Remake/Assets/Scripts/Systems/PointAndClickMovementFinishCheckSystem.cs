using Components;
using Events;
using Leopotam.EcsLite;
using UnityEngine.AI;

namespace Systems
{
    public class PointAndClickMovementFinishCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<PointAndClickMovementComponent>().End();
            var pointAndClickMovementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            foreach (var entity in filter)
            {
                var navMeshAgent = pointAndClickMovementComponentPool.Get(entity).NavMeshAgent;
                CheckFinish(navMeshAgent, ecsWorld, entity);
            }
        }

        private void CheckFinish(NavMeshAgent navMeshAgent, EcsWorld ecsWorld, int entity)
        {
            if (navMeshAgent.pathPending) return;
            if (!navMeshAgent.hasPath && !(navMeshAgent.velocity.sqrMagnitude > 0.0f)) return;
            if (!(navMeshAgent.remainingDistance - navMeshAgent.stoppingDistance < 0.1f)) return;
            SetFinishMovingEvent(ecsWorld, entity);
        }

        private void SetFinishMovingEvent(EcsWorld ecsWorld, int entity)
        {
            var playerFinishMovingEventPool = ecsWorld.GetPool<PlayerFinishMovingEvent>();
            playerFinishMovingEventPool.Add(entity);
        }
    }
}