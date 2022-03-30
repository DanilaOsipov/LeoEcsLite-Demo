namespace Other
{
    public interface IVector
    {
        float X { get; }
        float Y { get; }
        float Z { get; }
        float Distance(IVector to);
        bool IsApproximate(IVector to);
        IVector Subtract(IVector vector);
        IVector Add(IVector vector);
        IVector Multiply(float by);
        IVector Normalized { get; }
    }
}