using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour
{
    public GameObject targetBody;
    private Animator animator;    
    
    void Start()
    {
        animator = targetBody.GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    public void BodyRotateAnim()
    {
        animator.SetTrigger("RotateTower");
    }
}
