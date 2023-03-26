using UnityEngine;

public class Zoom : MonoBehaviour
{    
    public GameObject target;
    [SerializeField] private float sensitivity = 0.005f;
    private Vector2 f0start;
    private Vector2 f1start;


    // Gizmo for target
    public float MinRaduis = 4f;
    public float MaxRaduis = 8f; 
    public float DistanceToTarget;

    private void Update()
    {
        CheckTouchCount();       
    }

    private void CheckTouchCount()
    {
        if(Input.touchCount < 2)
        {
            f0start = Vector2.zero;
            f1start = Vector2.zero;
        }
        if(Input.touchCount == 2)
        {
            ZoomCamera();
        }
    }

    private void ZoomCamera()
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
            print(dir);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, dir * sensitivity * Time.deltaTime * Vector3.Distance(f0position, f1position));   
                    
            Vector3 clampedPosition = transform.position;
            
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.1f, 4.1f);
            
            transform.position = clampedPosition;
        }                   
    }

}
