using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PopUps
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private PopupData popUpData;

        private void OnMouseDown()
        {
            Debug.Log(popUpData.name);
            Debug.Log(popUpData.PopupName);
            Debug.Log(popUpData.PopupDescription);
            //Debug.Log(popUpData.PopupIcon.name);
        }
    }
}