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
            var pointAndClickPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            var positionPool = ecsWorld.GetPool<PositionComponent>();
            var enablingListenerPool = ecsWorld.GetPool<EnablingListenerComponent>();
            foreach (var pointAndClickEntity in ecsWorld.Filter<PointAndClickMovementComponent>()
                .Inc<StartMovingEvent>().End())
            {
                foreach (var endMarkerEntity in ecsWorld.Filter<PointAndClickMovementEndMarkerComponent>()
                    .Inc<EnablingListenerComponent>().Inc<PositionComponent>().End())
                {
                    var destination = pointAndClickPool.Get(pointAndClickEntity).Destination;
                    positionPool.Get(endMarkerEntity).UpdateListener.OnPositionUpdate(destination);    
                    enablingListenerPool.Get(endMarkerEntity).EnablingListener.OnEnabling();
                }
            }
        }

        private void CheckPlayerFinishMovingEvent(EcsWorld ecsWorld)
        {
            var enablingListenerPool = ecsWorld.GetPool<EnablingListenerComponent>();
            foreach (var pointAndClickEntity in ecsWorld.Filter<PointAndClickMovementComponent>()
                .Inc<FinishMovingEvent>().End())
            {
                foreach (var endMarkerEntity in ecsWorld.Filter<PointAndClickMovementEndMarkerComponent>()
                    .Inc<EnablingListenerComponent>().End())
                {
                    enablingListenerPool.Get(endMarkerEntity).EnablingListener.OnDisabling();
                }
            }
        }
    }
}