using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{
    public class CanvasControl : NetworkBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private ITextureChangable _textureChangable;

        private void Awake()
        {
            // Находим класс релизующий интерфейс
            _textureChangable = FindObjectOfType<CanvasHistory>();
            if (_textureChangable == null)
            {
                Debug.LogError("CanvasHistory component not found in the scene!");
            }
        }

        public void OnPointerClick(PointerEventData data)
        {
            _textureChangable?.TextureChangeOn("Textures/HistoryMode/Cabine");
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
