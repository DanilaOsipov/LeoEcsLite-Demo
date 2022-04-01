using System.Collections.Generic;
using Components;
using Other;
using UnityEngine;

namespace EventListeners.Unity
{
    public class EnablingListener : EventListener<EnablingListenerComponent>, IEnablingListener
    {
        [SerializeField] private List<EventReaction> _enablingReactions;

        public void OnEnabling()
        {
            gameObject.SetActive(true);
            _enablingReactions.ForEach(x => x.OnEventTriggered());
        }

        public void OnDisabling() => gameObject.SetActive(false);

        protected override void InitializeComponent(ref EnablingListenerComponent component) 
            => component.EnablingListener = this;
    }
}