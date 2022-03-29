using Components;
using Events;
using Leopotam.EcsLite;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementEndMarkerUpdateSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            CheckPlayerStartMovingEvent(ecsWorld);
            CheckPlayerFinishMovingEvent(ecsWorld);
        }

        private void CheckPlayerStartMovingEvent(EcsWorld ecsWorld)
        {
            if (ecsWorld.Filter<PlayerStartMovingEvent>().End().GetEntitiesCount() == 0) return;
            var endMarkerFilter = ecsWorld.Filter<PointAndClickMovementEndMarkerComponent>().End();
            var endMarkerComponentPool = ecsWorld.GetPool<PointAndClickMovementEndMarkerComponent>();
            var pointAndClickFilter = ecsWorld.Filter<PointAndClickMovementComponent>().End();
            var pointAndClickComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            foreach (var endMarkerEntity in endMarkerFilter)
            {
                foreach (var pointAndClickEntity in pointAndClickFilter)
                {
                    ref var endMarkerComponent = ref endMarkerComponentPool.Get(endMarkerEntity);
                    endMarkerComponent.MarkerGameObject.transform.position =
                        pointAndClickComponentPool.Get(pointAndClickEntity).NavMeshAgent.destination;
                    endMarkerComponent.MarkerShowParticleSystem.Clear();
                    endMarkerComponent.MarkerGameObject.SetActive(true);
                    endMarkerComponent.MarkerShowParticleSystem.Play(true);
                }
            }
        }

        private void CheckPlayerFinishMovingEvent(EcsWorld ecsWorld)
        {
            if (ecsWorld.Filter<PlayerFinishMovingEvent>().End().GetEntitiesCount() == 0) return;
            var endMarkerFilter = ecsWorld.Filter<PointAndClickMovementEndMarkerComponent>().End();
            var endMarkerComponentPool = ecsWorld.GetPool<PointAndClickMovementEndMarkerComponent>();
            foreach (var endMarkerEntity in endMarkerFilter)
            {
                ref var endMarkerComponent = ref endMarkerComponentPool.Get(endMarkerEntity);
                endMarkerComponent.MarkerGameObject.SetActive(false);
            }
        }
    }
}