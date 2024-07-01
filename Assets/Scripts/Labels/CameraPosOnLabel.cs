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
        [SerializeField] private LabelData _labelData;
        [SerializeField] private Transform _cameraPos;

        //private void Start()
        //{
        //    labelData = GetComponent<LabelData>();
        //}

        private void OnEnable()
        {
            Label labelLookAt = FindObjectOfType<Label>();
            labelLookAt.OnActionTouchLabel += ActionTouchLabel;
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            Camera.main.transform.position = _cameraPos.transform.position;
            Camera.main.transform.rotation = _cameraPos.transform.rotation;
            //Camera.main.transform.position = _labelData.CameraPos; //new Vector3(-0.864f, 2.511f, -3.51f);
            //Camera.main.transform.rotation = _labelData.CameraRot;
            //Camera.main.transform.LookAt(transform);
        }
    }
}
