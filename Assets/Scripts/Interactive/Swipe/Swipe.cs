using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform target;
    public Camera cam;

    public float currentRotateX;
    public float sensitivitySwipe = 0.1f;    
    private Vector2 deltaValue = Vector2.zero;

    private void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cam = FindObjectOfType<Camera>();        
    }

    private void Update()
    {
        currentRotateX = deltaValue.x;
        // currentRotateY = deltaValue.y;

        // Rotate
        cam.transform.RotateAround(target.position, Vector3.up, currentRotateX * sensitivitySwipe * Time.deltaTime); 
        // cam.transform.RotateAround(target.position, Vector3.right, currentRotateX * sensitivitySwipe * Time.deltaTime); 
             
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
