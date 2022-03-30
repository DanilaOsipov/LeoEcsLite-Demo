using UnityEngine;

namespace Other
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        public void PlayMoving() => _animator.SetBool(IsRunning, true);

        public void PlayIdle() => _animator.SetBool(IsRunning, false);
    }
}