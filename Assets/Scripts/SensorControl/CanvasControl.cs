using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{
    public class CanvasControl : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private INotifiable notifiable;
        private void Awake()
        {
            //Находим класс релизазующий интерфейс
            notifiable = FindObjectOfType<CanvasRunHistory>();
        }

        public void OnPointerClick(PointerEventData data)
        {
            notifiable?.Notify("Notification from CanvasControl");
        }

        public void OnBeginDrag(PointerEventData data)
        {

        }

        public void OnDrag(PointerEventData data)
        {

        }

        public void OnEndDrag(PointerEventData data)
        {

        }
    }
}
