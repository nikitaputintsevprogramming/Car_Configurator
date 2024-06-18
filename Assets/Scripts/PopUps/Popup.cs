using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PopUps
{
    public class PopUp : MonoBehaviour, IOutlinear
    {
        [SerializeField] private PopupData popUpData;

        private Outline _outline;

        private void OnMouseDown()
        {
            Debug.Log(popUpData.name);
            Debug.Log(popUpData.PopupName);
            Debug.Log(popUpData.PopupDescription);
            //Debug.Log(popUpData.PopupIcon.name);
        }

        public void SetOutline(float intensity)
        {
            Debug.Log("SetOutline on " + intensity);
        }

        void Lightning()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.yellow;
            _outline.OutlineWidth = 5f;
        }
    }
}