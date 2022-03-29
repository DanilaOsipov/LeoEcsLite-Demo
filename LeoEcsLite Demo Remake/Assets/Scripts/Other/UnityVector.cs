using UnityEngine;

namespace Other
{
    public struct UnityVector : IVector
    {
        public Vector3 Value;
        
        public UnityVector(Vector3 value) => Value = value;
        
        public bool IsApproximate(IVector to) => ((UnityVector)to).Value == Value;
    }
}