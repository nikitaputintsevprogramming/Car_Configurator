using UnityEngine.EventSystems;
using UnityEngine;

public class SwipeZoom : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform target;
    public Camera cam;

    // zoom start
    public Vector3 offset;
    public float pitch = 2f;
    public float currentZoom;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private Vector2 f0start;
    private Vector2 f1start;
    // zoom end

    // swipe start
    public float yawSpeed = 100f;
    public float currentYaw;
    public float currentRotateX;
    public float sensitivitySwipe = 0.1f;    
    private Vector2 deltaValue = Vector2.zero;
    // swipe end

    private void Start()
    {
        cam = Camera.main;
        currentZoom = maxZoom;
        cam.transform.position = target.position - offset * currentZoom;
    }

    private void Update()
    {
        if(Input.touchCount < 2)
        {
            f0start = Vector2.zero;
            f1start = Vector2.zero;
        }
        if(Input.touchCount == 2)
        {
            if (f0start == Vector2.zero && f1start == Vector2.zero)
            {
                f0start = Input.GetTouch(0).position;
                f1start = Input.GetTouch(1).position;
            }

            Vector2 f0position = Input.GetTouch(0).position;
            Vector2 f1position = Input.GetTouch(1).position;

            if(Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position) != 0 )
            {
                float dir = -Mathf.Sign(Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position)); 
                // обработка зума 
                currentZoom -= dir * zoomSpeed;
                currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            }
        }

        // обработка поворота камеры вокруг игрока
        currentYaw -= deltaValue.x * yawSpeed * Time.deltaTime;       

        
    }

    private void LateUpdate()
    {
        // ставим камеру в позицию игрока с отступом и зумом
        cam.transform.position = target.position - offset * currentZoom;
        // смотрим на игрока 
        cam.transform.LookAt(target.position + Vector3.up * pitch);

        // поворот вокруг игрока
        cam.transform.RotateAround(target.position, Vector3.up, currentYaw * sensitivitySwipe);
    }

    public void OnBeginDrag(PointerEventData data)
    {
        deltaValue = Vector2.zero;
    }

    public void OnDrag(PointerEventData data)
    {        
        if (data.dragging)
        {
            deltaValue += data.delta;                                         
        }        
        
    }

    public void OnEndDrag(PointerEventData data)
    {
        deltaValue = Vector2.zero;
    }
}
