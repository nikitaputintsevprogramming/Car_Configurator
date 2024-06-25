using System.Collections;
using UnityEngine;

namespace T34
{
    public class PopUp : MonoBehaviour, IOutlinear
    {
        [SerializeField] private PopupData popUpData;

        private Outline _outline;

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