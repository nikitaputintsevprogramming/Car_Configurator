using UnityEngine;
using UnityEngine.UI;

namespace Buttons.Movement
{
    public class AnimationController : MonoBehaviour
    {       
        public Sprite[] LightSprites;
        public GameObject LightButton;        

        public GameObject tankTarget;
        public Animator tankAnimator;               

        private void Start()
        {
            tankAnimator = tankTarget.GetComponent<Animator>();
        }

        public void PlayAnimation(string nameTriggerAnimation)
        {
            if(tankAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                tankAnimator.SetTrigger(nameTriggerAnimation);
            }
        }

        public void Lights(GameObject lightsParent)
        {
            Light[] lights = lightsParent.GetComponentsInChildren<Light>();
            for (int count = 0; count < lights.Length; count++)
            {
                lights[count].enabled = !lights[count].enabled;
                if(lights[count].enabled)
                {
                    LightButton.GetComponent<Image>().sprite = LightSprites[1];
                }
                else
                {
                    LightButton.GetComponent<Image>().sprite = LightSprites[0];
                }
            }
            
        }
    }
}
