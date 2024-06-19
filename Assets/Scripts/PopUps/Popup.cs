using System.Collections;
using UnityEngine;

namespace T34
{
    public class PopUp : MonoBehaviour, IOutlinear
    {
        [SerializeField] private PopupData popUpData;

        private Outline _outline;
        private Material _material;

        //private void Awake()
        //{
        //    // Находим класс релизующий интерфейс
        //    swipeCameraController = FindObjectOfType<SwipeCameraController>();
        //    if (swipeCameraController == null)
        //    {
        //        Debug.LogError("CanvasHistory component not found in the scene!");
        //    }
        //}

        public void SetOutline(float intensity)
        {
            Debug.Log("SetOutline on " + intensity);
            Lightning(intensity);
        }

        void Lightning(float intensity)
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.white;
            _outline.OutlineWidth = intensity;
        }

        private void OnMouseDown()
        {
            Debug.Log(popUpData.name);
            Debug.Log(popUpData.PopupName);
            Debug.Log(popUpData.PopupDescription);
            //Debug.Log(popUpData.PopupIcon.name);
        }
    }
}