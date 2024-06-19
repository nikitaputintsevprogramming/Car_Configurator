using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace T34
{
    public class PopUpOutline : CanvasControl
    {
        [SerializeField] private float _dist;
        [SerializeField] private float _minVal;
        [SerializeField] private float _maxVal;

        public override void OnDrag(PointerEventData eventData)
        {
            // �������� ��� ������� � ����������� PopUp, ������� ��������� ��������� IOutlinear
            PopUp[] popUpObjects = FindObjectsOfType<PopUp>();
            // ������� ������� ������
            Vector3 currentPosition = Camera.main.transform.position;

            foreach (PopUp popUpObject in popUpObjects)
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
        }
    }
}