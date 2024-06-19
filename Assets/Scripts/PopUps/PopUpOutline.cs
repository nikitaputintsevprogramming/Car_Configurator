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
            // Получаем все объекты с компонентом PopUp, которые реализуют интерфейс IOutlinear
            PopUp[] popUpObjects = FindObjectsOfType<PopUp>();
            // Текущая позиция камеры
            Vector3 currentPosition = Camera.main.transform.position;

            foreach (PopUp popUpObject in popUpObjects)
            {
                // Проверяем, реализует ли объект интерфейс IOutlinear
                if (popUpObject is IOutlinear outlinearObject)
                {
                    // Расстояние от камеры до объекта
                    float distance = Vector3.Distance(currentPosition, popUpObject.transform.position);
                    // Вычисляем значение outline в зависимости от расстояния
                    float outlineValue = Mathf.Lerp(10, 0, distance / 5);
                    // Устанавливаем значение outline (при условии, что SetOutline принимает float)
                    outlinearObject.SetOutline(outlineValue);
                }
            }
        }
    }
}
