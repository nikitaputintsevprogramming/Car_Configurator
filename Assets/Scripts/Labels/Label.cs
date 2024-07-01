using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace T34
{
    public class Label : MonoBehaviour, IOutlinear
    {
        public event EventHandler OnActionTouchLabel;

        private Outline _outline;

        // Установка пределов для прозрачности
        [SerializeField] private float minDistance = 5.0f; // Минимальное расстояние, при котором объект полностью непрозрачный
        [SerializeField] private float maxDistance = 6.0f; // Максимальное расстояние, при котором объект полностью прозрачный

        // Установка пределов для прозрачности
        [SerializeField] private float minTransp = 0f; // Прозрачность при минимальном расстоянии (0 = полностью прозрачный)
        [SerializeField] private float maxTransp = 255f; // Прозрачность при максимальном расстоянии (255 = полностью непрозрачный)
        public void SetOutline(float intensity)
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.white;
            _outline.OutlineWidth = intensity;
        }

        private void OnEnable()
        {
            CanvasControl canvasControl = FindObjectOfType<CanvasControl>();
            canvasControl.OnActionOnDrag += ActionEvents_BeginDrag;

            OnActionTouchLabel += ActionTouchLabel;
        }

        private void ActionEvents_BeginDrag(object sender, EventArgs e)
        {
            Debug.Log("ActionEvents_BeginDrag");
            Vector3 targetPos = transform.position - Camera.main.transform.position;
            transform.LookAt(targetPos);

            // Вычисление расстояния между объектом и камерой
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            // Вычисление значения прозрачности с использованием Mathf.Lerp
            float transparencyValue = Mathf.Lerp(maxTransp, minTransp, (distance - minDistance) / (maxDistance - minDistance));
            transparencyValue = Mathf.Clamp(transparencyValue, minTransp, maxTransp); // Ограничиваем значение прозрачности от 0 до 255

            // Установка нового цвета материала с вычисленным значением прозрачности
            Material mat = transform.GetComponent<Renderer>().material;
            Color color = mat.color;
            color.a = transparencyValue / 255f; // Преобразуем значение из 0-255 в 0-1
            mat.color = color;

            Debug.LogFormat("Дистанция: {0}, Значение прозрачности: {1}", distance, transparencyValue);
        }

        private void ActionTouchLabel(object sender, EventArgs e)
        {
            Material mat = transform.GetComponent<Renderer>().material;
            Color color = mat.color;
            color.a = 0; // Преобразуем значение из 0-255 в 0-1
            mat.color = color;
        }

        private void OnMouseDown()
        {
            Debug.Log(gameObject.name);
            OnActionTouchLabel?.Invoke(this, EventArgs.Empty);
        }
    }
}
