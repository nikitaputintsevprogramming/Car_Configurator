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
        //private IOutlinear _outlinear;
        private bool _imageChangedOnStart;



        private void Awake()
        {
            // Находим класс релизующий интерфейс
            _textureChangable = FindObjectOfType<CanvasHistory>();
            //_outlinear = FindObjectOfType<PopUp>();
            if (_textureChangable == null) Debug.LogError("CanvasHistory component not found in the scene!");
            //if (_outlinear == null) Debug.LogError("PopUp component not found in the scene!");
        }

        public void OnPointerClick(PointerEventData data)
        {


        }

        public void OnBeginDrag(PointerEventData data)
        {
            if (_imageChangedOnStart)
                return;

            _textureChangable?.TextureChangeOn("Textures/HistoryMode/Cabine");
            //_textureChangable.TextureChangeOn("Textures/HistoryMode/Cabine");
            _imageChangedOnStart = true; // Set the flag to true after the image is changed
        }

        public virtual void OnDrag(PointerEventData data)
        {
  
        }

        public void OnEndDrag(PointerEventData data)
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
