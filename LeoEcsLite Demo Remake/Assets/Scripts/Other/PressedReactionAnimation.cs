using UnityEngine;

namespace Other
{
    public class PressedReactionAnimation : ButtonPressedReaction
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IS_PRESSED = Animator.StringToHash("IsPressed");

        public override void OnButtonPressed() => _animator.SetBool(IS_PRESSED, true);
    }
}