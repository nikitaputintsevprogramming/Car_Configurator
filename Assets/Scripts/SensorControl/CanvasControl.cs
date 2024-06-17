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
            //Находим класс релизазующий интерфейс
            _textureChangable = FindObjectOfType<CanvasHistory>();
        }

        public void OnPointerClick(PointerEventData data)
        {
            // Check if the network is active
            //if (NetworkManager.Singleton.IsServer)
            //{
                _textureChangable?.TextureChangeOn("Textures/HistoryMode/Cabine");
            //}
            //else
            //{
            //    Debug.LogWarning("Network is not active. Click event ignored.");
            //}
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
