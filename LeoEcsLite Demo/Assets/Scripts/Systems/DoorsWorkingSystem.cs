using Components;
using Leopotam.EcsLite;
using Other;
using UnityEngine;

namespace Systems
{
    public class DoorsOperatingSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<DoorComponent>().End();
            var doorComponentPool = ecsWorld.GetPool<DoorComponent>();
            foreach (var entity in filter)
            {
                ref var doorComponent = ref doorComponentPool.Get(entity);
                if (doorComponent.DoorStatus == DeviceStatus.Working)
                {
                    UpdateDoorComponent(ref doorComponent);
                }
            }
        }

        private void UpdateDoorComponent(ref DoorComponent doorComponent)
        {
            var t = doorComponent.DoorOpenningElapsedTime / doorComponent.DoorOpenningDuration;
            var currentPos = doorComponent.DoorMeshTransform.position;
            var endPos = doorComponent.DoorOpenedStateTransform.position;
            doorComponent.DoorMeshTransform.position = Vector3.Lerp(currentPos, endPos, t);
            doorComponent.DoorOpenningElapsedTime += Time.fixedDeltaTime;
            if (Mathf.Approximately(t, 1.0f)) doorComponent.DoorStatus = DeviceStatus.Worked;
        }
    }
}