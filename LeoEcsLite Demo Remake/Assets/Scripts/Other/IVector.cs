namespace Other
{
    public interface IVector
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        bool IsApproximate(IVector to);
        IVector Subtract(IVector vector);
        IVector Add(IVector vector);
        IVector Multiply(float by);
        IVector Normalized { get; }
    }
}