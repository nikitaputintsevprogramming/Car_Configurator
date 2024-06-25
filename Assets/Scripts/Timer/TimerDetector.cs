using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace T34
{
    public class TimerDetector : MonoBehaviour
    {
        [SerializeField] private float _endTime;
        [SerializeField] private float _currTime;
        [SerializeField] private float _reserveTime;

        public event EventHandler OnActionTimerEnds;

        private void OnEnable()
        {
            CanvasControl _canvasControl = FindObjectOfType<CanvasControl>();
            _canvasControl.OnActionPointerClick += ActionPointerClick;
        }

        private void Update()
        {
            Timer();
        }

        public bool Timer()
        {
            _currTime = Time.timeSinceLevelLoad - _reserveTime;
            if (_currTime >= _endTime)
            {
                Debug.Log("Время таймера вышло");
                OnActionTimerEnds?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;
        }

        private void ResetTimer()
        {
            _reserveTime += _currTime;
        }

        private void ActionPointerClick(object sender, EventArgs e)
        {
            ResetTimer();
        }
    }
}