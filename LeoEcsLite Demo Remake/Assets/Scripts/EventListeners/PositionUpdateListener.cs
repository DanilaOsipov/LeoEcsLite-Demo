using UnityEngine;

namespace EventListeners
{
    public class PositionUpdateListener : MonoBehaviour, IPositionUpdateListener
    {
        public void OnPositionUpdate(Vector3 value) => transform.position = value;
    }
}