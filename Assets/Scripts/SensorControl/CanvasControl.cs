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
        private TextureChangable _textureChangable;
        private void Awake()
        {
            //Находим класс релизазующий интерфейс
            _textureChangable = FindObjectOfType<CanvasHistory>();
        }

        public void OnPointerClick(PointerEventData data)
        {
            _textureChangable?.TextureChangeOn("Cabine");
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
