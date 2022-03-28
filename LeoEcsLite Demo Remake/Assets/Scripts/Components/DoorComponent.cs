using System;
using Other;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct DoorComponent
    {
        public int DoorId;
        public Transform DoorMeshTransform;
        public Transform DoorOpenedStateTransform;
        public float DoorOpenningDuration;
        public float DoorOpenningElapsedTime;
        public DeviceStatus DoorStatus;
    }
}