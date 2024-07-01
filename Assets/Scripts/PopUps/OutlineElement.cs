using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace T34
{
    public class OutlineElement : CanvasControl
    {
        [SerializeField] private float _dist;
        [SerializeField] private float _minVal;
        [SerializeField] private float _maxVal;

        private void OnEnable()
        {
            //CanvasControl canvasControl = FindObjectOfType<CanvasControl>();
            //canvasControl.OnActionOnDrag += ActionOnDrag;

            Label labelLookAt = FindObjectOfType<Label>();
            labelLookAt.OnActionTouchLabel += ActionTouchLabel;
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            //�������� ��� ������� � ����������� PopUp, ������� ��������� ��������� IOutlinear
            OutlineElementManaged[] popUpObjects = FindObjectsOfType<OutlineElementManaged>();
            // ������� ������� ������
            Vector3 currentPosition = Camera.main.transform.position;

            foreach (OutlineElementManaged popUpObject in popUpObjects)
            {
                // ���������, ��������� �� ������ ��������� IOutlinear
                if (popUpObject is IOutlinear outlinearObject)
                {
                    // ���������� �� ������ �� �������
                    float distance = Vector3.Distance(currentPosition, popUpObject.transform.position);
                    // ��������� �������� outline � ����������� �� ����������
                    float outlineValue = Mathf.Lerp(_maxVal, _minVal, distance / _dist);
                    // ������������� �������� outline (��� �������, ��� SetOutline ��������� float)
                    outlinearObject.SetOutline(outlineValue);
                }
            }

            //private void ActionOnDrag(object sender, EventArgs e)
            //{
            //    // �������� ��� ������� � ����������� PopUp, ������� ��������� ��������� IOutlinear
            //    OutlineElementManaged[] popUpObjects = FindObjectsOfType<OutlineElementManaged>();
            //    // ������� ������� ������
            //    Vector3 currentPosition = Camera.main.transform.position;

            //    foreach (OutlineElementManaged popUpObject in popUpObjects)
            //    {
            //        // ���������, ��������� �� ������ ��������� IOutlinear
            //        if (popUpObject is IOutlinear outlinearObject)
            //        {
            //            // ���������� �� ������ �� �������
            //            float distance = Vector3.Distance(currentPosition, popUpObject.transform.position);
            //            // ��������� �������� outline � ����������� �� ����������
            //            float outlineValue = Mathf.Lerp(_maxVal, _minVal, distance / _dist);
            //            // ������������� �������� outline (��� �������, ��� SetOutline ��������� float)
            //            outlinearObject.SetOutline(outlineValue);
            //        }
            //    }
            //}
        }
    }
}