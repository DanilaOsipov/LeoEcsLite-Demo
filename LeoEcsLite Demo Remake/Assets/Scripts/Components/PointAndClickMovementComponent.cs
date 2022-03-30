using System;
using Other;
using UnityEngine.AI;

namespace Components
{
    [Serializable]
    public struct PointAndClickMovementComponent
    {
        public IVector Destination;
        public float Speed;
        public float StoppingDistance;
        public NavMeshAgent NavMeshAgent;
    }
}