using UnityEngine;

namespace Buttons.Movement
{
    public class AnimationController : MonoBehaviour
    {
        public GameObject tankTarget;
        public Animator tankAnimator;

        public string currentAnimation;

        private void Start()
        {
            tankAnimator = tankTarget.GetComponent<Animator>();
        }

        public void PlayAnimation(string nameTriggerAnimation)
        {
            if(!tankAnimator.GetCurrentAnimatorStateInfo(0).IsName("StayCalm"))
            {
                return;
            }

            tankAnimator.SetTrigger(nameTriggerAnimation);
            
        }
    }
}
