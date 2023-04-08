using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float xSpeed = 120f;
    public float ySpeed = 120f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float distanceMin = 0.5f;
    public float distanceMax = 15f;
    public float smoothTime = 0.2f;
    public float zoomSpeed = 5f;

    private float x = 0f;
    private float y = 0f;
    private float currentDistance;
    private float targetDistance;
    private Vector3 smoothVelocity = Vector3.zero;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        currentDistance = distance;
        targetDistance = distance;
    }

    private void LateUpdate()
    {
        if (target)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                x += Input.GetTouch(0).deltaPosition.x * xSpeed * 0.02f;
                y -= Input.GetTouch(0).deltaPosition.y * ySpeed * 0.02f;
                y = ClampAngle(y, yMinLimit, yMaxLimit);
            }

            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                float touchDeltaMag = (touch1.position - touch2.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                targetDistance += deltaMagnitudeDiff * zoomSpeed * 0.02f;
                targetDistance = Mathf.Clamp(targetDistance, distanceMin, distanceMax);
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0f);
            Vector3 negDistance = new Vector3(0f, 0f, -targetDistance);
            Vector3 position = rotation * negDistance + target.position;

            RaycastHit hit;
            if (Physics.Linecast(target.position, position, out hit))
            {
                targetDistance -= hit.distance;
                targetDistance = Mathf.Clamp(targetDistance, distanceMin, distanceMax);
            }

            currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance, ref smoothVelocity.z, smoothTime);
            position = rotation * new Vector3(0f, 0f, -currentDistance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
        {
            angle += 360f;
        }
        if (angle > 360f)
        {
            angle -= 360f;
        }
        return Mathf.Clamp(angle, min, max);
    }


}
