using UnityEngine;

namespace Other
{
    public struct UnityVector : IVector
    {
        public Vector3 Value;
        
        public UnityVector(Vector3 value) => Value = value;
        
        public bool IsApproximate(IVector to) => ((UnityVector)to).Value == Value;
        
        public IVector Subtract(IVector vector) => new UnityVector(Value - ((UnityVector)vector).Value);
        
        public IVector Add(IVector vector) => new UnityVector(Value + ((UnityVector)vector).Value);
        
        public IVector Multiply(float by) => new UnityVector(Value * by);

        public IVector Normalized  => new UnityVector(Value.normalized);
    }
}