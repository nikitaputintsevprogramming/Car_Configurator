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
        //public Vector3 flagPosition; // ������� �����
        public GameObject labelCanvas; // ������ ��� ����������� �������� � �������� 
        public TMP_Text titleText; // ����� ��� ��������
        //public LineRenderer lineRenderer; // ����� ��� �������� �� ������

        void Start()
        {
            SetActiveFlag(false);
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
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            SetActiveFlag(true);

            //Vector3 targetPos = labelCanvas.GetComponent<RectTransform>() - Camera.main.transform.position;
            labelCanvas.GetComponent<RectTransform>().LookAt(Camera.main.transform);
        }

        void SetActiveFlag(bool setOn)
        {
            labelCanvas.SetActive(setOn);
            titleText.gameObject.SetActive(setOn);
        }
    }
}

