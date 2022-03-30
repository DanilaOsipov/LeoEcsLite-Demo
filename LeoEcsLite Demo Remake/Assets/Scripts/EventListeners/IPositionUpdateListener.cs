using Other;

namespace EventListeners
{
    public interface IPositionUpdateListener
    {
        void OnPositionUpdate(IVector value);
    }
}