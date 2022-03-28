using Components;
using Events;
using Leopotam.EcsLite;
using Other;

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

        private void CheckPlayerMovingEvent<TMovingEvent>(EcsWorld ecsWorld, string animatorParamToSet,
            bool animatorParamValue) where TMovingEvent : struct
        {
            var filter = ecsWorld.Filter<TMovingEvent>().Inc<PlayerAnimatorComponent>().End();
            var playerAnimatorComponentPool = ecsWorld.GetPool<PlayerAnimatorComponent>();
            foreach (var entity in filter)
            {
                ref var playerAnimatorComponent = ref playerAnimatorComponentPool.Get(entity);
                playerAnimatorComponent.PlayerAnimator.SetBool(animatorParamToSet, animatorParamValue);
            }
        }
        
        private void CheckPlayerStartMovingEvent(EcsWorld ecsWorld) => CheckPlayerMovingEvent<PlayerStartMovingEvent>
            (ecsWorld, Constants.PLAYER_RUNNING_ANIMATOR_PARAMETER, true);

        private void CheckPlayerFinishMovingEvent(EcsWorld ecsWorld) => CheckPlayerMovingEvent<PlayerFinishMovingEvent>
            (ecsWorld, Constants.PLAYER_RUNNING_ANIMATOR_PARAMETER, false);
    }
}