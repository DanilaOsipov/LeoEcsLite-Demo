namespace EventListeners
{
    public interface IButtonPressedListener
    {
        int ListenedButtonId { get; }
        void OnButtonPressed();
    }
}