using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace EventListeners
{
    [RequireComponent(typeof(ConvertToEntity))]
    public abstract class EventListener : MonoBehaviour, IEventListener
    {
        private int? _entity;
            
        public int? TryGetEntity() => _entity ??= GetComponent<ConvertToEntity>().TryGetEntity();

        public abstract void Register(EcsWorld ecsWorld);
    }
}