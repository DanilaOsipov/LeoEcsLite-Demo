using EventListeners;
using Other;

namespace Components
{
    public struct DirectionComponent
    {
        public IVector Value;
        public IDirectionUpdateListener UpdateListener;
    }
}