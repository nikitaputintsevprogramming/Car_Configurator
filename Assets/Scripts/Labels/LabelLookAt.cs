using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{
    public class LabelLookAt : MonoBehaviour
    {
        // ��������� �������� ��� ������������
        [SerializeField] private float minDistance = 5.0f; // ����������� ����������, ��� ������� ������ ��������� ������������
        [SerializeField] private float maxDistance = 6.0f; // ������������ ����������, ��� ������� ������ ��������� ����������

        // ��������� �������� ��� ������������
        [SerializeField] private float minTransp = 0f; // ������������ ��� ����������� ���������� (0 = ��������� ����������)
        [SerializeField] private float maxTransp = 255f; // ������������ ��� ������������ ���������� (255 = ��������� ������������)

        private void OnEnable()
        {
            CanvasControl canvasControl = FindObjectOfType<CanvasControl>();
            canvasControl.OnActionOnDrag += ActionEvents_BeginDrag;
        }

        private void ActionEvents_BeginDrag(object sender, EventArgs e)
        {
            Debug.Log("ActionEvents_BeginDrag");
            Vector3 targetPos = transform.position - Camera.main.transform.position;
            transform.LookAt(targetPos);

            // ���������� ���������� ����� �������� � �������
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            // ���������� �������� ������������ � �������������� Mathf.Lerp
            float transparencyValue = Mathf.Lerp(maxTransp, minTransp, (distance - minDistance) / (maxDistance - minDistance));
            transparencyValue = Mathf.Clamp(transparencyValue, minTransp, maxTransp); // ������������ �������� ������������ �� 0 �� 255

            // ��������� ������ ����� ��������� � ����������� ��������� ������������
            Material mat = transform.GetComponent<Renderer>().material;
            Color color = mat.color;
            color.a = transparencyValue / 255f; // ����������� �������� �� 0-255 � 0-1
            mat.color = color;

            Debug.LogFormat("���������: {0}, �������� ������������: {1}", distance, transparencyValue);
        }

        private void OnMouseDown()
        {
            Debug.Log(gameObject.name);
        }
    }
}
