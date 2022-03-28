using Components;
using Events;
using Leopotam.EcsLite;
using Other;

namespace Systems
{
    public class PlayerDoorOperatorCheckSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<PlayerGroundHitEvent>().End();
            var playerGroundHitEventPool = ecsWorld.GetPool<PlayerGroundHitEvent>();
            foreach (var entity in filter)
            {
                var playerGroundHitEvent = playerGroundHitEventPool.Get(entity);
                CheckHit(playerGroundHitEvent, ecsWorld);
            }
        }

        private void CheckHit(PlayerGroundHitEvent playerGroundHitEvent, EcsWorld ecsWorld)
        {
            var doorOperatorComponentPool = ecsWorld.GetPool<DoorOperatorComponent>();
            foreach (var entity in ecsWorld.Filter<DoorOperatorComponent>().End())
            {
                ref var doorOperatorComponent = ref doorOperatorComponentPool.Get(entity);
                var isDoorOperatorHitted 
                    = playerGroundHitEvent.HitInfo.collider == doorOperatorComponent.DoorOperatorCollider;
                var isDoorOperatorWaiting = doorOperatorComponent.DoorOperatorStatus == DeviceStatus.Waiting;
                if (!isDoorOperatorHitted || !isDoorOperatorWaiting) continue;
                StartDoorOperating(ecsWorld, ref doorOperatorComponent);
                return;
            }
        }

        private void StartDoorOperating(EcsWorld ecsWorld, ref DoorOperatorComponent doorOperatorComponent)
        {
            doorOperatorComponent.DoorOperatorStatus = DeviceStatus.Working;
            var filter = ecsWorld.Filter<DoorComponent>().End();
            var doorComponentPool = ecsWorld.GetPool<DoorComponent>();
            foreach (var entity in filter)
            {
                ref var doorComponent = ref doorComponentPool.Get(entity);
                if (doorOperatorComponent.DoorOperatorId == doorComponent.DoorId)
                    doorComponent.DoorStatus = DeviceStatus.Working;
            }
        }
    }
}