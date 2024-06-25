using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{ 
    public class CanvasControl : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private ITextureChangable _textureChangable;
        private bool _imageChangedOnStart;

        public event EventHandler OnActionPointerClick;

        private void Awake()
        {
            // Находим класс релизующий интерфейс
            _textureChangable = FindObjectOfType<CanvasHistory>();
            if (_textureChangable == null) Debug.LogError("CanvasHistory component not found in the scene!");
        }

        public virtual void OnPointerClick(PointerEventData data)
        {
            OnActionPointerClick?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnBeginDrag(PointerEventData data)
        {
            if (_imageChangedOnStart)
                return;

            _imageChangedOnStart = true;
        }

        public virtual void OnDrag(PointerEventData data)
        {
  
        }

        public virtual void OnEndDrag(PointerEventData data)
        {

        }
    }

    enum Part
    {
        Run = 1,
        History = 0,
        Action = 0
    }
}
