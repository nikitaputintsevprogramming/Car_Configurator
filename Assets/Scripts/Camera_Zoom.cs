using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{
    public float sensitivity;

    Vector2 f0start;
    Vector2 f1start;


    public Transform target;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;          

    void Update()
    {                

        if (Input.touchCount < 2)
        {
            f0start = Vector2.zero;
            f1start = Vector2.zero;
        }
        if (Input.touchCount == 2) 
        {
            Zoom();
        }
    }
 
    void Zoom()
    {
        if (f0start == Vector2.zero && f1start == Vector2.zero)
        {
            f0start = Input.GetTouch(0).position;
            f1start = Input.GetTouch(1).position;
        }

        Vector2 f0position = Input.GetTouch(0).position;
        Vector2 f1position = Input.GetTouch(1).position;
        float dir = Mathf.Sign(Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position));
        Mathf.Clamp(dir, minZoom, maxZoom);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, dir * sensitivity * Time.deltaTime * Vector3.Distance(f0position, f1position)) * zoomSpeed;
    }
}
