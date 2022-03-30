using EventListeners;
using Other;

namespace Components
{
    public struct PositionComponent
    {
        public IVector Value;
        public IPositionUpdateListener UpdateListener;
    }
}