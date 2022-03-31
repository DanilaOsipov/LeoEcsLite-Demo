using Components;
using Leopotam.EcsLite;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementEndMarkerInitSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems) => HideMarkers(systems);

        private static void HideMarkers(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var listenerPool = ecsWorld.GetPool<EnablingListenerComponent>();
            foreach (var endMarkerEntity in ecsWorld.Filter<PointAndClickMovementEndMarkerComponent>()
                .Inc<EnablingListenerComponent>().End())
            {
                ref var endMarkerComponent = ref listenerPool.Get(endMarkerEntity);
                endMarkerComponent.EnablingListener.OnDisabling();
            }
        }
    }
}