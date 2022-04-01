using UnityEngine;

namespace Other
{
    public class ReactionParticle : EventReaction
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        public override void OnEventTriggered()
        {
            _particleSystem.Clear();
            _particleSystem.Play(true);
        }
    }
}