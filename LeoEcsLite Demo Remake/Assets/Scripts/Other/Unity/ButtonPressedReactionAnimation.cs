using UnityEngine;

namespace Other.Unity
{
    public class ButtonPressedReactionAnimation : EventReaction
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IS_PRESSED = Animator.StringToHash("IsPressed");

        public override void OnEventTriggered() => _animator.SetBool(IS_PRESSED, true);
    }
}