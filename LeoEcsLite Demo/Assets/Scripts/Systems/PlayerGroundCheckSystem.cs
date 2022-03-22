using Components;
using Events;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using UnityEngine;

namespace Systems
{
    public class PlayerGroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<IPhysicsService> _physicsService;
        
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<PlayerComponent>().End();
            var playerComponentPool = ecsWorld.GetPool<PlayerComponent>();
            foreach (var entity in filter)
            {
                var playerComponent = playerComponentPool.Get(entity);
                CheckGround(playerComponent, ecsWorld);
            }
        }

        private void CheckGround(PlayerComponent playerComponent, EcsWorld ecsWorld)
        {
            if (!_physicsService.Value.CastRay(playerComponent.PlayerTransform.position, Vector3.down,
                out var hitInfo)) return;
            var playerGroundHitEventPool = ecsWorld.GetPool<PlayerGroundHitEvent>();
            var entity = ecsWorld.NewEntity();
            playerGroundHitEventPool.Add(entity);
            ref var playerGroundHitEvent = ref playerGroundHitEventPool.Get(entity);
            playerGroundHitEvent.HitInfo = hitInfo;
        }
    }
}