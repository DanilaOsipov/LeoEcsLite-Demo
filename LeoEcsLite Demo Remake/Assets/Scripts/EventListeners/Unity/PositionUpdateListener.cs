using Components;
using Other;

namespace EventListeners.Unity
{
    public class PositionUpdateListener : EventListener<PositionComponent>, IPositionUpdateListener
    {
        public void OnPositionUpdate(IVector value) => transform.position = UnityVector.CreateVector3(value);
        
        protected override void InitializeComponent(ref PositionComponent component)
        {
            component.Value = new UnityVector(transform.position);
            component.UpdateListener = this;
        }
    }
}