using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{
    public class CanvasControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static event Action<Sprite> OnBeginDragEvent;
        [SerializeField] private Sprite HistoryModeSprite;

        public void OnBeginDrag(PointerEventData data)
        {
            OnBeginDragEvent?.Invoke(HistoryModeSprite);
        }

        public void OnDrag(PointerEventData data)
        {

        }

        public void OnEndDrag(PointerEventData data)
        {

        }
    }
}
