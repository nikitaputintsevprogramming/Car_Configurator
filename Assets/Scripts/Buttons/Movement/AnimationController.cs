using UnityEngine;

namespace Buttons.Movement
{
    public class AnimationController : MonoBehaviour
    {
        public GameObject tankTarget;
        public Animator tankAnimator;

        private void Start()
        {
            tankAnimator = tankTarget.GetComponent<Animator>();
        }

        public void PlayAnimation(string nameTriggerAnimation)
        {
            tankAnimator.SetTrigger(nameTriggerAnimation);
        }
    }
}
