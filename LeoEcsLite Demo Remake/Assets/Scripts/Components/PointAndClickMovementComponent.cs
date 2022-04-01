using System;
using Other;

namespace Components
{
    [Serializable]
    public struct PointAndClickMovementComponent
    {
        public IVector Destination;
        public float Speed;
        public float StoppingDistance;
    }
}