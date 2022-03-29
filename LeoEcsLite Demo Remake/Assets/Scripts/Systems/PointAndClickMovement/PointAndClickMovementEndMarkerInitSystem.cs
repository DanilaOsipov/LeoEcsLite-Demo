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