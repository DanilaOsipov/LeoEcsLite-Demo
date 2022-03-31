using Components;
using Leopotam.EcsLite;

namespace EventListeners.Unity
{
    public class EnablingListener : EventListener, IEnablingListener
    {
        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var directionPool = ecsWorld.GetPool<EnablingListenerComponent>();
            ref var listenerComponent = ref directionPool.Add(entity.Value);
            listenerComponent.EnablingListener = this;
        }

        public void OnEnabling() => gameObject.SetActive(true);

        public void OnDisabling() => gameObject.SetActive(false);
    }
}