using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interactive
{
    public class SwipeZoom : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform target;
        public Camera cam;

        // zoom start
        public Vector3 offset;
        public float pitch = 2f;
        public float currentZoom;
        public float zoomSpeed = 4f;
        public float minZoom = 5f;
        public float maxZoom = 15f;
    
        private Vector2 _f0Start;
        private Vector2 _f1Start;
        // zoom end

        // swipe start
        public float yawSpeed = 100f;
        public float currentYaw;
        public float currentRotateX;
        public float sensitivitySwipe = 0.1f;
        
        private Vector2 _deltaValue = Vector2.zero;
        // swipe end

        private void Start()
        {
            cam = Camera.main;

            if (cam == null)
                throw new NullReferenceException("Main camera is not found!");

            currentZoom = maxZoom;
            cam.transform.position = target.position - offset * currentZoom;
        }

        private void Update()
        {
            switch (Input.touchCount)
            {
                case < 2:
                {
                    _f0Start = Vector2.zero;
                    _f1Start = Vector2.zero;
                    break;
                }
                case 2:
                {
                    if (_f0Start == Vector2.zero && _f1Start == Vector2.zero)
                    {
                        _f0Start = Input.GetTouch(0).position;
                        _f1Start = Input.GetTouch(1).position;
                    }

                    var f0Position = Input.GetTouch(0).position;
                    var f1Position = Input.GetTouch(1).position;

                    if(Vector2.Distance(_f1Start, _f0Start) - Vector2.Distance(f0Position, f1Position) != 0 )
                    {
                        var dir = -Mathf.Sign(Vector2.Distance(_f1Start, _f0Start) - Vector2.Distance(f0Position, f1Position)); 
                        // обработка зума 
                        currentZoom -= dir * zoomSpeed;
                        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
                    }

                    break;
                }
            }

            // обработка поворота камеры вокруг игрока
            currentYaw -= _deltaValue.x * yawSpeed * Time.deltaTime;
        }

        private void LateUpdate()
        {
            // ставим камеру в позицию игрока с отступом и зумом
            var position = target.position;
            cam.transform.position = position - offset * currentZoom;
            // смотрим на игрока 
            cam.transform.LookAt(position + Vector3.up * pitch);

            // поворот вокруг игрока
            cam.transform.RotateAround(position, Vector3.up, currentYaw * sensitivitySwipe);
        }

        public void OnBeginDrag(PointerEventData data)
        {
            _deltaValue = Vector2.zero;
        }

        public void OnDrag(PointerEventData data)
        {        
            if (data.dragging)
            {
                _deltaValue += data.delta;                                         
            }        
        
        }

        public void OnEndDrag(PointerEventData data)
        {
            _deltaValue = Vector2.zero;
        }
    }
}
