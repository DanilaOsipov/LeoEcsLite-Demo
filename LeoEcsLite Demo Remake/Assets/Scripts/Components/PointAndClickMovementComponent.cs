using System;
using Other;
using UnityEngine.AI;

namespace Components
{
    [Serializable]
    public struct PointAndClickMovementComponent
    {
        public IVector Destination;
        public IVector AgentPosition;
        public float Speed;
        public NavMeshAgent NavMeshAgent;
    }
}