using System.Collections.Generic;
using Components;
using Leopotam.EcsLite;
using Other;
using UnityEngine;

namespace EventListeners.Unity
{
    public class EnablingListener : EventListener, IEnablingListener
    {
        [SerializeField] private List<EventReaction> _enablingReactions;
        
        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var directionPool = ecsWorld.GetPool<EnablingListenerComponent>();
            ref var listenerComponent = ref directionPool.Add(entity.Value);
            listenerComponent.EnablingListener = this;
        }

        public void OnEnabling()
        {
            gameObject.SetActive(true);
            _enablingReactions.ForEach(x => x.OnEventTriggered());
        }

        public void OnDisabling() => gameObject.SetActive(false);
    }
}