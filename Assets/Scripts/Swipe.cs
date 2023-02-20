using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform target;
    public Camera cam;

    public float currentRotate;
    public float sensitivity = 0.1f;
    private Vector2 deltaValue = Vector2.zero;

    private void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cam = FindObjectOfType<Camera>();        
    }

    private void Update()
    {
        currentRotate = deltaValue.x;

        // поворот вокруг игрока
        cam.transform.RotateAround(target.position, Vector3.up, currentRotate * sensitivity * Time.deltaTime); 
        print(deltaValue.x);        
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
