using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PopUps
{
    public class PopUpOutline : MonoBehaviour
    {
        [SerializeField] private PopUp[] _popups;

        private void Start()
        {
            _popups = FindObjectsOfType<PopUp>();
        }


    }
}
