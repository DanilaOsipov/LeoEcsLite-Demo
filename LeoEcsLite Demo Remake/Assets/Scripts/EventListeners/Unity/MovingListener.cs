using Components;
using Leopotam.EcsLite;
using Other;
using UnityEngine;

namespace EventListeners.Unity
{
    public class MovingListener : EventListener, IMovingListener
    {
        [SerializeField] private CharacterAnimator _animator;
        
        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var movingPool = ecsWorld.GetPool<MovingComponent>();
            ref var movingComponent = ref movingPool.Add(entity.Value);
            movingComponent.MovingListener = this;
        }

        public void OnStartMoving() => _animator.PlayMoving();

        public void OnStopMoving() => _animator.PlayIdle();
    }
}