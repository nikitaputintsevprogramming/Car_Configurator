using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{
    public class Popup : MonoBehaviour //, IOutlinear
    {
        public event EventHandler OnActionTouchLabel;

        // ��������� �������� ��� ������������
        [SerializeField] private float minDistance = 5.0f; // ����������� ����������, ��� ������� ������ ��������� ������������
        [SerializeField] private float maxDistance = 6.0f; // ������������ ����������, ��� ������� ������ ��������� ����������

        // ��������� �������� ��� ������������
        [SerializeField] private float minTransp = 0f; // ������������ ��� ����������� ���������� (0 = ��������� ����������)
        [SerializeField] private float maxTransp = 255f; // ������������ ��� ������������ ���������� (255 = ��������� ������������)

        private void Start()
        {
            Renderer render = transform.GetComponent<Renderer>();
            List<Material> materials = new List<Material>();
            render.GetMaterials(materials);
            foreach (Material material in materials)
            {
                if (material.name == "OutlineFill (Instance) (Instance)")
                {
                    // ���������� ��� ��� ����, ������� outline
                    material.SetFloat("_OutlineWidth", 0);
                }
            }
        }

        private void OnEnable()
        {
            CanvasControl canvasControl = FindObjectOfType<CanvasControl>();
            canvasControl.OnActionOnDrag += ActionEvents_OnDrag;

            OnActionTouchLabel += ActionTouchLabel;
        }

        private void ActionEvents_OnDrag(object sender, EventArgs e)
        {
            Vector3 targetPos = transform.position - Camera.main.transform.position;
            transform.LookAt(targetPos);

            // ���������� ���������� ����� �������� � �������
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            // ���������� �������� ������������ � �������������� Mathf.Lerp
            float transparencyValue = Mathf.Lerp(maxTransp, minTransp, (distance - minDistance) / (maxDistance - minDistance));
            transparencyValue = Mathf.Clamp(transparencyValue, minTransp, maxTransp); // ������������ �������� ������������ �� 0 �� 255

            Renderer render = transform.GetComponent<Renderer>();
            List<Material> materials = new List<Material>();
            render.GetMaterials(materials);

            foreach (Material material in materials)
            {
                Color color = material.color;
                color.a = transparencyValue / maxTransp;
                material.color = color;
            }

            Debug.LogFormat("���������: {0}, �������� ������������: {1}", distance, transparencyValue);
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            Renderer render = transform.GetComponent<Renderer>();
            List<Material> materials = new List<Material>();
            render.GetMaterials(materials);
            foreach (Material material in materials)
            {
                Color color = material.color;
                color.a = 0;
                material.color = color;
            }
        }

        private void OnMouseDown()
        {
            Debug.Log(gameObject.name);
            OnActionTouchLabel?.Invoke(this, EventArgs.Empty);
        }
    }
}
