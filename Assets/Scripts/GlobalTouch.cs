using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTouch : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
        } 
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown is working");
    }
}
