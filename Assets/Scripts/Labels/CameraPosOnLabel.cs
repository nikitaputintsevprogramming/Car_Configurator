using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace T34
{
    public class CameraPosOnLabel : MonoBehaviour
    {
        [SerializeField] private LabelData labelData;

        private void Start()
        {
            labelData = GetComponent<LabelData>();
        }

        private void OnEnable()
        {
            LabelLookAt labelLookAt = FindObjectOfType<LabelLookAt>();
            labelLookAt.OnActionTouchLabel += ActionTouchLabel;
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {

            Camera.main.transform.position = labelData.CameraPos; //new Vector3(-0.864f, 2.511f, -3.51f);
            Camera.main.transform.LookAt(transform);
        }
    }
}
