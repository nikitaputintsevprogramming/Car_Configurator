using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    public Transform target;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float yawSpeed = 100f;

    public Vector3 offset;
    public float pitch = 2f;

    public float currentZoom;
    public float currentYaw;


    void Update()
    {
        // обработка зума при скролле
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // обработка поворота камеры вокруг игрока
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        // ставим камеру в позицию игрока с отступом и зумом
        transform.position = target.position - offset * currentZoom;
        // смотрим на игрока 
        transform.LookAt(target.position + Vector3.up * pitch);

        // поворот вокруг игрока
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
