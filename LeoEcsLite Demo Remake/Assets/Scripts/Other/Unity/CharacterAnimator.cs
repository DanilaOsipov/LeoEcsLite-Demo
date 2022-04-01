using UnityEngine;

namespace Other.Unity
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IS_RUNNING = Animator.StringToHash("IsRunning");

        public void PlayMoving() => _animator.SetBool(IS_RUNNING, true);

        public void PlayIdle() => _animator.SetBool(IS_RUNNING, false);
    }
}