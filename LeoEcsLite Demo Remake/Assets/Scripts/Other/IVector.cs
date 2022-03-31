namespace Other
{
    public interface IVector
    {
        float X { get;  set; }
        float Y { get; set; }
        float Z { get; set; }
        IVector Copy { get; }
        IVector Normalized { get; }
        float Distance(IVector to);
        bool IsApproximate(IVector to);
        IVector Subtract(IVector vector);
        IVector Add(IVector vector);
        IVector Multiply(float by);
    }
}