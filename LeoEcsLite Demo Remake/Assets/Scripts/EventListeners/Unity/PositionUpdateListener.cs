using Components;
using Leopotam.EcsLite;
using Other;

namespace EventListeners
{
    public class PositionUpdateListener : EventListener, IPositionUpdateListener
    {
        public void OnPositionUpdate(IVector value) => transform.position = UnityVector.CreateVector3(value);

        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var positionPool = ecsWorld.GetPool<PositionComponent>();
            positionPool.Add(entity.Value);
            ref var positionComponent = ref positionPool.Get(entity.Value);
            positionComponent.Value = new UnityVector(transform.position);
            positionComponent.UpdateListener = this;
        }
    }
}