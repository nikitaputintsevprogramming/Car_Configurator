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

        // Установка пределов для прозрачности
        [SerializeField] private float minDistance = 5.0f; // Минимальное расстояние, при котором объект полностью непрозрачный
        [SerializeField] private float maxDistance = 6.0f; // Максимальное расстояние, при котором объект полностью прозрачный

        // Установка пределов для прозрачности
        [SerializeField] private float minTransp = 0f; // Прозрачность при минимальном расстоянии (0 = полностью прозрачный)
        [SerializeField] private float maxTransp = 255f; // Прозрачность при максимальном расстоянии (255 = полностью непрозрачный)

        private void Start()
        {
            Renderer render = transform.GetComponent<Renderer>();
            List<Material> materials = new List<Material>();
            render.GetMaterials(materials);
            foreach (Material material in materials)
            {
                if (material.name == "OutlineFill (Instance) (Instance)")
                {
                    // Исключение для поп апов, убираем outline
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

            // Вычисление расстояния между объектом и камерой
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            // Вычисление значения прозрачности с использованием Mathf.Lerp
            float transparencyValue = Mathf.Lerp(maxTransp, minTransp, (distance - minDistance) / (maxDistance - minDistance));
            transparencyValue = Mathf.Clamp(transparencyValue, minTransp, maxTransp); // Ограничиваем значение прозрачности от 0 до 255

            Renderer render = transform.GetComponent<Renderer>();
            List<Material> materials = new List<Material>();
            render.GetMaterials(materials);

            foreach (Material material in materials)
            {
                Color color = material.color;
                color.a = transparencyValue / maxTransp;
                material.color = color;
            }

            Debug.LogFormat("Дистанция: {0}, Значение прозрачности: {1}", distance, transparencyValue);
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
