using EventListeners.Unity;
using Leopotam.EcsLite;
using UnityEngine;

namespace Services.Unity
{
    public class UnityViewService : IViewService
    {
        public void RegisterListeners(EcsWorld ecsWorld)
        {
            foreach (var eventListener in Object.FindObjectsOfType<EventListener>())
            {
                eventListener.Register(ecsWorld);
            }
        }
    }
}