using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

namespace T34
{
    public class CanvasesController : MonoBehaviour
    {
        //public Vector3 flagPosition; // Позиция флага
        public GameObject flagCanvas; // Панель для отображения на хосте
        public GameObject infoCanvas; // Панель для отображения на клиенте
        public TMP_Text titleText;
        //public LineRenderer lineRenderer; // Линия для указания на панель

        void Start()
        {
            SetActiveFlag(false);
            SetActiveInfo(false);
        }
        private void OnEnable()
        {
            Popup labelLookAt = FindObjectOfType<Popup>();
            labelLookAt.OnActionTouchLabel += ActionTouchLabel;
            
            CanvasControl canvasControl = FindObjectOfType<CanvasControl>();
            canvasControl.OnActionOnDrag += ActionEvents_BeginDrag;
        }

        private void ActionEvents_BeginDrag(object sender, EventArgs e)
        {
            SetActiveFlag(false);
            SetActiveInfo(false);
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            SetActiveFlag(true);
            SetActiveInfo(true);

            //Vector3 targetPos = labelCanvas.GetComponent<RectTransform>() - Camera.main.transform.position;
            flagCanvas.GetComponent<RectTransform>().LookAt(Camera.main.transform);
        }

        void SetActiveFlag(bool setOn)
        {
            flagCanvas.SetActive(setOn);
            titleText.gameObject.SetActive(setOn);
        }

        void SetActiveInfo(bool setOn)
        {
            flagCanvas.SetActive(setOn);
            titleText.gameObject.SetActive(setOn);
        }
    }
}

