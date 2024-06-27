using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

namespace T34
{
    public class FlagController : MonoBehaviour
    {
        //public Vector3 flagPosition; // Позиция флага
        public GameObject labelCanvas; // Панель для отображения названия и описания 
        public TMP_Text titleText; // Текст для названия
        //public LineRenderer lineRenderer; // Линия для указания на панель

        void Start()
        {
            labelCanvas.SetActive(false);
            titleText.gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            LabelLookAt labelLookAt = FindObjectOfType<LabelLookAt>();
            labelLookAt.OnActionTouchLabel += ActionTouchLabel;
            
            CanvasControl canvasControl = FindObjectOfType<CanvasControl>();
            canvasControl.OnActionOnDrag += ActionEvents_BeginDrag;
        }

        private void ActionEvents_BeginDrag(object sender, EventArgs e)
        {
            labelCanvas.SetActive(false);
            titleText.gameObject.SetActive(false);
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            labelCanvas.SetActive(true);
            titleText.gameObject.SetActive(true);
            //Vector3 targetPos = labelCanvas.GetComponent<RectTransform>() - Camera.main.transform.position;
            labelCanvas.GetComponent<RectTransform>().LookAt(Camera.main.transform);
        }
    }
}

