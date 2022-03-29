using Other;

namespace Services
{
    public interface IInputService
    {
        ButtonStatus LeftMouseButtonStatus { get; }
        IVector MousePosition { get; }
    }
}