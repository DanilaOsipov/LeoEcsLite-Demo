using Components;
using Events;
using Leopotam.EcsLite;
using Other;

namespace Systems.PointAndClickMovement
{
    public class PointAndClickMovementStartCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems) => CheckPlayerInput(systems.GetWorld());

        private void CheckPlayerInput(EcsWorld ecsWorld)
        {
            var playerInputComponentPool = ecsWorld.GetPool<PlayerInputComponent>();
            foreach (var entity in ecsWorld.Filter<PlayerInputComponent>().End())
                CheckMouseState(playerInputComponentPool.Get(entity), ecsWorld);
        }

        private void CheckMouseState(PlayerInputComponent playerInputComponent, EcsWorld ecsWorld)
        {
            if (playerInputComponent.LeftMouseButtonStatus != ButtonStatus.Down) return;
            CheckMousePosition(ecsWorld);
        }

        private void CheckMousePosition(EcsWorld ecsWorld)
        {
            var mouseHitComponentPool = ecsWorld.GetPool<MouseHitComponent>();
            var movementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            foreach (var mouseHitEntity in ecsWorld.Filter<MouseHitComponent>().End())
            {
                var hitInfo = mouseHitComponentPool.Get(mouseHitEntity).HitInfo;
                if (hitInfo.LayerName != Constants.WALKABLE_LAYER) continue;
                foreach (var movementEntity in ecsWorld.Filter<PointAndClickMovementComponent>().End())
                {
                    ref var movementComponent = ref movementComponentPool.Get(movementEntity);
                    movementComponent.Destination = hitInfo.Position; 
                    ecsWorld.GetPool<PlayerStartMovingEvent>().Add(movementEntity);
                }
            }
        }
    }
}