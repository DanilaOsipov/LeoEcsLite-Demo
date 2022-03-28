using System;
using Other;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct DoorOperatorComponent
    {
        public int DoorOperatorId;
        public Collider DoorOperatorCollider;
        public Transform DoorOperatorMeshTransform;
        public Transform DoorOperatorWorkedStateTransform;
        public float DoorOperatorWorkingDuration;
        public float DoorOperatorWorkingElapsedTime;
        public DeviceStatus DoorOperatorStatus;
    }
}