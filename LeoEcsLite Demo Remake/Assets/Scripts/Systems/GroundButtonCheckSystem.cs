using Components;
using Events;
using Leopotam.EcsLite;

namespace Systems
{
    public class GroundButtonCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var hitEventPool = ecsWorld.GetPool<GroundHitEvent>();
            foreach (var entity in ecsWorld.Filter<GroundHitEvent>().End())
                CheckHit(hitEventPool.Get(entity), ecsWorld, ecsWorld.GetPool<ButtonComponent>());
        }

        private void CheckHit(GroundHitEvent groundHitEvent, EcsWorld ecsWorld, EcsPool<ButtonComponent> buttonPool)
        {
            var hitEntity = groundHitEvent.HitInfo.Entity;
            if (hitEntity == null) return;
            if (!buttonPool.Has(hitEntity.Value)) return;
            ref var buttonComponent = ref buttonPool.Get(hitEntity.Value);
            if (buttonComponent.IsPressed) return;
            buttonComponent.IsPressed = true;
            CallButtonListeners(ecsWorld, buttonComponent);
        }

        private void CallButtonListeners(EcsWorld ecsWorld, ButtonComponent buttonComponent)
        {
            var buttonListenerPool = ecsWorld.GetPool<ButtonPressedListenerComponent>();
            foreach (var entity in ecsWorld.Filter<ButtonPressedListenerComponent>().End())
            {
                ref var listener = ref buttonListenerPool.Get(entity).ButtonPressedListener;
                if (buttonComponent.Id == listener.ListenedButtonId) listener.OnButtonPressed();
            }
        }
    }
}