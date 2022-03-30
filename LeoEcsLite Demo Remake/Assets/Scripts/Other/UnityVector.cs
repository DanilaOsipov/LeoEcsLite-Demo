using UnityEngine;

namespace Other
{
    public struct UnityVector : IVector
    {
        private Vector3 _value;

        public float X => _value.x;
        
        public float Y => _value.y;

        public float Z => _value.z;
        
        public UnityVector(Vector3 value) => _value = value;

        public bool IsApproximate(IVector to) => CreateVector3(to) == _value;

        public IVector Subtract(IVector vector) => new UnityVector(_value - CreateVector3(vector));
        
        public IVector Add(IVector vector) => new UnityVector(_value + CreateVector3(vector));
        
        public IVector Multiply(float by) => new UnityVector(_value * by);

        public IVector Normalized  => new UnityVector(_value.normalized);

        public static Vector3 CreateVector3(IVector from) => from == null 
            ? Vector3.zero : new Vector3(from.X, from.Y, from.Z);
    }
}