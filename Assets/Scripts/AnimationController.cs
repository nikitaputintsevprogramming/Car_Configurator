using UnityEngine;
using UnityEngine.UI;

namespace Buttons.Movement
{
    public class AnimationController : MonoBehaviour
    {       
        public Sprite[] LightSprites;
        public GameObject CanvasPumps;
        public GameObject LightButton;        

        public GameObject tankTarget;
        public Animator tankAnimator;  

        private bool NoAnimationNow = true;            

        private void Start()
        {
            tankAnimator = tankTarget.GetComponent<Animator>();
        }

        private void Update()
        {
            if(tankAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                NoAnimationNow = true;
                CanvasPumps.SetActive(true);
            }
            else
            {
                CanvasPumps.SetActive(false);
            }
        }

        public void PlayAnimation(string nameTriggerAnimation)
        {
            if(NoAnimationNow)
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
