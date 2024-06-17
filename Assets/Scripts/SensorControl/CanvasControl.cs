
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
        public void OnPointerClick(PointerEventData data)
        {
            //CanvasRunHistory.Notify += CanvasRunHistory.OnNotifyReceived;
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
