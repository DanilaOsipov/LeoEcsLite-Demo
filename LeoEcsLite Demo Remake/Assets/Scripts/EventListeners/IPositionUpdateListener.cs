using UnityEngine;

namespace EventListeners
{
    public interface IPositionUpdateListener
    {
        void OnPositionUpdate(Vector3 value);
    }
}