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
            //Получаем все объекты с компонентом PopUp, которые реализуют интерфейс IOutlinear
            OutlineElementManaged[] popUpObjects = FindObjectsOfType<OutlineElementManaged>();
            // Текущая позиция камеры
            Vector3 currentPosition = Camera.main.transform.position;

            foreach (OutlineElementManaged popUpObject in popUpObjects)
            {
                // Проверяем, реализует ли объект интерфейс IOutlinear
                if (popUpObject is IOutlinear outlinearObject)
                {
                    // Расстояние от камеры до объекта
                    float distance = Vector3.Distance(currentPosition, popUpObject.transform.position);
                    // Вычисляем значение outline в зависимости от расстояния
                    float outlineValue = Mathf.Lerp(_maxVal, _minVal, distance / _dist);
                    // Устанавливаем значение outline (при условии, что SetOutline принимает float)
                    outlinearObject.SetOutline(outlineValue);
                }
            }

            //private void ActionOnDrag(object sender, EventArgs e)
            //{
            //    // Получаем все объекты с компонентом PopUp, которые реализуют интерфейс IOutlinear
            //    OutlineElementManaged[] popUpObjects = FindObjectsOfType<OutlineElementManaged>();
            //    // Текущая позиция камеры
            //    Vector3 currentPosition = Camera.main.transform.position;

            //    foreach (OutlineElementManaged popUpObject in popUpObjects)
            //    {
            //        // Проверяем, реализует ли объект интерфейс IOutlinear
            //        if (popUpObject is IOutlinear outlinearObject)
            //        {
            //            // Расстояние от камеры до объекта
            //            float distance = Vector3.Distance(currentPosition, popUpObject.transform.position);
            //            // Вычисляем значение outline в зависимости от расстояния
            //            float outlineValue = Mathf.Lerp(_maxVal, _minVal, distance / _dist);
            //            // Устанавливаем значение outline (при условии, что SetOutline принимает float)
            //            outlinearObject.SetOutline(outlineValue);
            //        }
            //    }
            //}
        }
    }
}