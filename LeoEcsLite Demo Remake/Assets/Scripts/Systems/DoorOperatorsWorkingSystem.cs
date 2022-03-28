using Components;
using Leopotam.EcsLite;
using Other;
using UnityEngine;

namespace Systems
{
    public class DoorOperatorsWorkingSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<DoorOperatorComponent>().End();
            var doorOperatorComponentPool = ecsWorld.GetPool<DoorOperatorComponent>();
            foreach (var entity in filter)
            {
                ref var doorOperatorComponent = ref doorOperatorComponentPool.Get(entity);
                if (doorOperatorComponent.DoorOperatorStatus == DeviceStatus.Working)
                {
                    UpdateDoorComponent(ref doorOperatorComponent);
                }
            }
        }
        
        private void UpdateDoorComponent(ref DoorOperatorComponent doorOperatorComponent)
        {
            var t = doorOperatorComponent.DoorOperatorWorkingElapsedTime 
                    / doorOperatorComponent.DoorOperatorWorkingDuration;
            var currentPos = doorOperatorComponent.DoorOperatorMeshTransform.position;
            var endPos = doorOperatorComponent.DoorOperatorWorkedStateTransform.position;
            doorOperatorComponent.DoorOperatorMeshTransform.position = Vector3.Lerp(currentPos, endPos, t);
            doorOperatorComponent.DoorOperatorWorkingElapsedTime += Time.fixedDeltaTime;
            if (Mathf.Approximately(t, 1.0f)) doorOperatorComponent.DoorOperatorStatus = DeviceStatus.Worked;
        }
    }
}