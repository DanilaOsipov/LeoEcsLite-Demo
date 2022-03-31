using System.Collections.Generic;
using Components;
using Leopotam.EcsLite;
using Other;
using UnityEngine;

namespace EventListeners.Unity
{
    public class ButtonPressedListener : EventListener, IButtonPressedListener
    {
        [SerializeField] private int _listenedButtonId;
        [SerializeField] private List<ButtonPressedReaction> _pressedReaction;
        
        public int ListenedButtonId => _listenedButtonId;

        public override void Register(EcsWorld ecsWorld)
        {
            var entity = TryGetEntity();
            if (entity == null) return;
            var buttonListenerPool = ecsWorld.GetPool<ButtonPressedListenerComponent>();
            ref var listenerComponent = ref buttonListenerPool.Add(entity.Value);
            listenerComponent.ButtonPressedListener = this;
        }

        public void OnButtonPressed() => _pressedReaction.ForEach(x => x.OnButtonPressed());
    }
}