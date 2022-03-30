using Components;
using Leopotam.EcsLite;
using Other;

namespace EventListeners
{
    public class DirectionUpdateListener : EventListener, IDirectionUpdateListener
    {
        public void OnDirectionUpdate(IVector value) => transform.forward = UnityVector.CreateVector3(value);

        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var directionPool = ecsWorld.GetPool<DirectionComponent>();
            directionPool.Add(entity.Value);
            ref var directionComponent = ref directionPool.Get(entity.Value);
            directionComponent.Value = new UnityVector(transform.position);
            directionComponent.UpdateListener = this;
        }
    }
}