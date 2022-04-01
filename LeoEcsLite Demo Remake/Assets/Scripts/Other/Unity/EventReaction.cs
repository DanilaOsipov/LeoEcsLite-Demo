using UnityEngine;

namespace Other.Unity
{
    public abstract class EventReaction : MonoBehaviour
    {
        public abstract void OnEventTriggered();
    }
}