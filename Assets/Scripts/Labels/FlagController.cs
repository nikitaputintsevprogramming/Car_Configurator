using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace T34
{
    public class FlagController : MonoBehaviour
    {
        public Vector3 flagPosition; // Позиция флага
        public GameObject uiPanel; // Панель для отображения названия и описания
        public TMP_Text titleText; // Текст для названия
        public TMP_Text descriptionText; // Текст для описания
        public LineRenderer lineRenderer; // Линия для указания на панель

        void Start()
        {

        }

        void Update()
        {
        }
    }
}


