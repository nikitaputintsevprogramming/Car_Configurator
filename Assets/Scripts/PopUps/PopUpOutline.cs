using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace T34
{
    public class PopUpOutline : CanvasControl
    {
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
                    float outlineValue = Mathf.Lerp(10, 0, distance / 5);
                    // ������������� �������� outline (��� �������, ��� SetOutline ��������� float)
                    outlinearObject.SetOutline(outlineValue);
                }
            }
        }
    }
}
