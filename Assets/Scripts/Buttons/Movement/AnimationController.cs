using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject TankTarget;
    public Animator TankAnimator;

    void Start()
    {
        TankAnimator = TankTarget.GetComponent<Animator>();
    }
    
    void Update()
    {
        
    }

    public void PlayAnimation(string nameTriggerAnimation)
    {
        TankAnimator.SetTrigger(nameTriggerAnimation);
    }
}
