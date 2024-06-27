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
        public TMP_Text descriptionText; // ����� ��� ��������
        //public LineRenderer lineRenderer; // ����� ��� �������� �� ������

        void Start()
        {
            labelCanvas.SetActive(false);
            titleText.gameObject.SetActive(false);
            descriptionText.gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            LabelLookAt labelLookAt = FindObjectOfType<LabelLookAt>();
            labelLookAt.OnActionTouchLabel += ActionTouchLabel;
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            labelCanvas.SetActive(true);
            titleText.gameObject.SetActive(true);
            descriptionText.gameObject.SetActive(true);
            //Vector3 targetPos = labelCanvas.GetComponent<RectTransform>() - Camera.main.transform.position;
            labelCanvas.GetComponent<RectTransform>().LookAt(Camera.main.transform);
        }

        //private void Update()
        //{
        //    //if(Input.GetKey(KeyCode.W))
        //    //{
        //        //Vector3 targetPos = uiPanel.transform.position - Camera.main.transform.position;
        //        labelCanvas.GetComponent<RectTransform>().LookAt(Camera.main.transform);
        //    //}
        //}
    }
}

