using UnityEngine;

namespace Other.Unity
{
    public struct UnityVector : IVector
    {
        private Vector3 _value;

        public float X
        {
            get => _value.x;
            set => _value.x = value;
        }

        public float Y
        {
            get => _value.y;
            set => _value.y = value;
        }

        public float Z
        {
            get => _value.z;
            set => _value.z = value;
        }

        public IVector Copy =>  new UnityVector(_value);

        public IVector Normalized  => new UnityVector(_value.normalized);
        
        public UnityVector(Vector3 value) => _value = value;

        public float Distance(IVector to) => Vector3.Distance(CreateVector3(to), _value);

        public bool IsApproximate(IVector to) => CreateVector3(to) == _value;

        public IVector Subtract(IVector vector) => new UnityVector(_value - CreateVector3(vector));

        public IVector Add(IVector vector) => new UnityVector(_value + CreateVector3(vector));

        public IVector Multiply(float by) => new UnityVector(_value * by);

        public static Vector3 CreateVector3(IVector from) => new Vector3(from.X, from.Y, from.Z);
    }
}