using System.Collections.Generic;
using Components;
using Other;
using Other.Unity;
using UnityEngine;

namespace EventListeners.Unity
{
    public class ButtonPressedListener : EventListener<ButtonPressedListenerComponent>, IButtonPressedListener
    {
        [SerializeField] private int _listenedButtonId;
        [SerializeField] private List<EventReaction> _pressedReactions;
        
        public int ListenedButtonId => _listenedButtonId;

        public void OnButtonPressed() => _pressedReactions.ForEach(x => x.OnEventTriggered());
        
        protected override void InitializeComponent(ref ButtonPressedListenerComponent component) 
            => component.ButtonPressedListener = this;
    }
}