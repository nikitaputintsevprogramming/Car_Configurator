using UnityEngine;
using UnityEngine.EventSystems;

public class Canvas_Swipe : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    Transform green;   // здесь будет ссылка на компонент Transform зеленой панели.
    public Transform target;

    public float directionSpeed;

    public float currentSwipe;
    public float swipeSpeed = 100f;
    public float pitch = 2f;

    void Start()
    {
        green = transform.GetChild(0); // получаем ссылку на Transform зеленой панели.
    }

    void Update()
    {
        currentSwipe -= directionSpeed * swipeSpeed * Time.deltaTime;
    }

    void LateUpdate()
    { 
        // смотрим на игрока 
        transform.LookAt(target.position + Vector3.up * pitch);

        // поворот вокруг игрока
        transform.RotateAround(target.position, Vector3.up, currentSwipe);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0) 
            {
                Debug.Log("Right");
                directionSpeed = 1;
            }
            else 
            {
                Debug.Log("Left");
                directionSpeed = -1;
            }

            // green.position += new Vector3(eventData.delta.x, 0, 0);
        }

        // else
        // {
        //     if (eventData.delta.y > 0) 
        //     {
        //         Debug.Log("Up");
        //     }
        //     else 
        //     {
        //         Debug.Log("Down");
        //     }

        //     green.position += new Vector3(0, eventData.delta.y, 0);
        // }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
