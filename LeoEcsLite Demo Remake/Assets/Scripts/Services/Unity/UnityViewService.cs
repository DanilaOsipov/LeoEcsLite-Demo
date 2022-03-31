using EventListeners;
using Leopotam.EcsLite;
using UnityEngine;

namespace Services
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