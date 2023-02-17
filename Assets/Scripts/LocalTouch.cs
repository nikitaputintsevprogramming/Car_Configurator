using UnityEngine;
using UnityEngine.EventSystems;

public class LocalTouch : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    // Обработка Click жестов
    public void OnPointerClick(PointerEventData eventDataClick)
    {
        Debug.Log(eventDataClick.position);
    }

    public void OnPointerDown(PointerEventData eventDataDown)
    {
        Debug.Log(eventDataDown.position);
    }

    public void OnPointerEnter(PointerEventData eventDataEnter)
    {
        Debug.Log(eventDataEnter.position);
    }

    public void OnPointerExit(PointerEventData eventDataExit)
    {
        Debug.Log(eventDataExit.position);
    }

    public void OnPointerMove(PointerEventData eventDataMove)
    {
        Debug.Log(eventDataMove.position);
    }

    public void OnPointerUp(PointerEventData eventDataUp)
    {
        Debug.Log(eventDataUp.position);
    }
    
    // Обработка Swipe жестов
    public void OnDrag(PointerEventData eventDataDrag)
    {

    }

    public void OnBeginDrag(PointerEventData eventDataBeginDrag)
    {

    }

    public void OnEndDrag(PointerEventData eventDataEndDrag)
    {

    }
}
