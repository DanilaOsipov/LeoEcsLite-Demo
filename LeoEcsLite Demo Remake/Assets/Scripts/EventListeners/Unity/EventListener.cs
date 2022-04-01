using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace EventListeners.Unity
{
    [RequireComponent(typeof(ConvertToEntity))]
    public abstract class EventListener : MonoBehaviour, IEventListener
    {
        private int? _entity;
            
        public int? TryGetEntity() => _entity ??= GetComponent<ConvertToEntity>().TryGetEntity();

        public abstract void Register(EcsWorld ecsWorld);
    }

    public abstract class EventListener<TComponent> : EventListener where TComponent : struct
    {
        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            ref var component = ref ecsWorld.GetPool<TComponent>().Add(entity.Value);
            InitializeComponent(ref component);
        }

        protected abstract void InitializeComponent(ref TComponent component);
    }
}