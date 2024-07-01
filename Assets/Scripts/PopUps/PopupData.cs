using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T34
{
    [CreateAssetMenu(fileName = "new PopupData", menuName = "PopupData", order = 51)]
    public class PopupData : ScriptableObject
    {
        [SerializeField] private string popupName;
        [SerializeField] private string popupDescription;
        [SerializeField] private Sprite popupIcon;

        public string PopupName
        {
            get
            {
                return popupName;
            }
        }

        public Sprite PopupIcon
        {
            get
            {
                return popupIcon;
            }
        }
    }
}