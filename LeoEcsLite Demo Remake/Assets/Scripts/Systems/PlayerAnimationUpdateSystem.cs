using Components;
using Events;
using Leopotam.EcsLite;

namespace Systems
{
    public class PlayerAnimationUpdateSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            CheckPlayerStartMovingEvent(ecsWorld);
            CheckPlayerFinishMovingEvent(ecsWorld);
        }

        private void CheckPlayerStartMovingEvent(EcsWorld ecsWorld) => CheckPlayerMovingEvent<PlayerStartMovingEvent>
            (ecsWorld, true);

        private void CheckPlayerFinishMovingEvent(EcsWorld ecsWorld) => CheckPlayerMovingEvent<PlayerFinishMovingEvent>
            (ecsWorld, false);

        private void CheckPlayerMovingEvent<TMovingEvent>(EcsWorld ecsWorld, bool isMoving) where TMovingEvent : struct
        {
            var movingPool = ecsWorld.GetPool<MovingComponent>();
            foreach (var entity in ecsWorld.Filter<TMovingEvent>().Inc<MovingComponent>().End())
            {
                ref var movingComponent = ref movingPool.Get(entity);
                var movingListener = movingComponent.MovingListener;
                if (isMoving) movingListener.OnStartMoving();
                else movingListener.OnStopMoving();
            }
        }
    }
}