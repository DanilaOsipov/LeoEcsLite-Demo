using Components;
using Leopotam.EcsLite;
using Other;

namespace EventListeners.Unity
{
    public class DirectionUpdateListener : EventListener, IDirectionUpdateListener
    {
        public void OnDirectionUpdate(IVector value) => transform.forward = UnityVector.CreateVector3(value);

        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var directionPool = ecsWorld.GetPool<DirectionComponent>();
            ref var directionComponent = ref directionPool.Add(entity.Value);
            directionComponent.Value = new UnityVector(transform.position);
            directionComponent.UpdateListener = this;
        }
    }
}