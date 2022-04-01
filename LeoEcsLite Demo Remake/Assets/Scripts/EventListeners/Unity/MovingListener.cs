using Components;
using Other.Unity;
using UnityEngine;

namespace EventListeners.Unity
{
    public class MovingListener : EventListener<MovingComponent>, IMovingListener
    {
        [SerializeField] private CharacterAnimator _animator;
        
        public void OnStartMoving() => _animator.PlayMoving();

        public void OnStopMoving() => _animator.PlayIdle();
        
        protected override void InitializeComponent(ref MovingComponent component) => component.MovingListener = this;
    }
}