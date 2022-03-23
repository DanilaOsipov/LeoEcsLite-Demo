using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Other;
using Services;
using UnityEngine;

namespace Systems
{
    public class PointAndClickMovementStartCheckSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<IPhysicsService> _physicsService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<PlayerInputComponent>().End();
            var playerInputComponentPool = ecsWorld.GetPool<PlayerInputComponent>();
            foreach (var entity in filter)
            {
                var playerInputComponent = playerInputComponentPool.Get(entity);
                CheckMouseState(playerInputComponent, ecsWorld);
            }
        }

        private void CheckMouseState(PlayerInputComponent playerInputComponent, EcsWorld ecsWorld)
        {
            var isLeftMouseButtonDown = playerInputComponent.LeftMouseButtonStatus == ButtonStatus.Down;
            if (!isLeftMouseButtonDown) return;
            CheckMousePosition(playerInputComponent, ecsWorld);
        }

        private void CheckMousePosition(PlayerInputComponent playerInputComponent, EcsWorld ecsWorld)
        {
            var filter = ecsWorld.Filter<PointAndClickMovementComponent>().End();
            var pointAndClickMovementComponentPool = ecsWorld.GetPool<PointAndClickMovementComponent>();
            foreach (var entity in filter)
            {
                var mousePosition = playerInputComponent.MousePosition;
                var pointAndClickMovementComponent = pointAndClickMovementComponentPool.Get(entity);
                if (!_physicsService.Value.CastRayFromScreenPoint(mousePosition, out var hitInfo)) continue;
                if (hitInfo.transform.gameObject.layer != LayerMask.NameToLayer(Constants.WALKABLE_LAYER)) continue;
                pointAndClickMovementComponent.NavMeshAgent.SetDestination(hitInfo.point);
                SetStartMovingEvent(ecsWorld, entity);
            }
        }

        private void SetStartMovingEvent(EcsWorld ecsWorld, int entity)
        {
            var playerStartMovingEventPool = ecsWorld.GetPool<PlayerStartMovingEvent>();
            playerStartMovingEventPool.Add(entity);
        }
    }
}