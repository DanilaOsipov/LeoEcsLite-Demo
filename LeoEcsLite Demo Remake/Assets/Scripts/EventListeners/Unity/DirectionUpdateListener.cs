using Components;
using Other;
using Other.Unity;

namespace EventListeners.Unity
{
    public class DirectionUpdateListener : EventListener<DirectionComponent>, IDirectionUpdateListener
    {
        public void OnDirectionUpdate(IVector value) => transform.forward = UnityVector.CreateVector3(value);
        
        protected override void InitializeComponent(ref DirectionComponent component)
        {
            component.Value = new UnityVector(transform.position);
            component.UpdateListener = this;
        }
    }
}