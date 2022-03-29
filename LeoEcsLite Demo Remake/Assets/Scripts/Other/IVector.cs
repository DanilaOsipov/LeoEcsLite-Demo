namespace Other
{
    public interface IVector
    {
        bool IsApproximate(IVector to);
        IVector Subtract(IVector vector);
        IVector Add(IVector vector);
        IVector Multiply(float by);
        IVector Normalized { get; }
    }
}