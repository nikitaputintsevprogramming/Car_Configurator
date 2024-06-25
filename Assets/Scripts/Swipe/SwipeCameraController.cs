using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace T34
{
    [RequireComponent(typeof(Image))]
    public class SwipeCameraController : CanvasControl
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _speed;

        [SerializeField] private bool _presentation;
        [SerializeField] private Vector3 _camStartPos;
        [SerializeField] private float _presentSpeed;

        [SerializeField] private float angleX;
        [SerializeField] private float angleY;
        [SerializeField] private bool invertVector;

        [SerializeField] List<GameObject> _tracks;
        DefaultControls.Resources knob;

        [SerializeField] private float angle;
        [SerializeField] private float radius = 10;
        [SerializeField] private float degreesPerSecond = 30;

        private void OnEnable()
        {
            CanvasControl _canvasControl = FindObjectOfType<CanvasControl>();
            _canvasControl.OnActionTouch += ActionPointerClick;
        }

        private void Start()
        {
            _presentation = true;

            TimerDetector timerDetector = FindObjectOfType<TimerDetector>();
            timerDetector.OnActionTimerEnds += ActionTimerEnds;

            CameraSetToStartPos();
        }

        private void CameraSetToStartPos()
        {
            //_camera.transform.position = Vector3.Lerp(_camera.transform.position, _camStartPos, _speed * Time.deltaTime);
            _camera.transform.position = _camStartPos;
            _camera.transform.LookAt(_target.position);
        }

        private void ActionTimerEnds(object sender, EventArgs e)
        {
            if (_presentation) return;
            CameraSetToStartPos();

            _presentation = true;
            Debug.Log("Режим презентации включен");
        }

        private void ActionPointerClick(object sender, EventArgs e)
        {
            _presentation = false;
        }

        private void FixedUpdate()
        {
            if (!_presentation)
                return;

            _camera.transform.RotateAround(_target.position, Vector3.up, _presentSpeed * Time.deltaTime);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            var _track = new GameObject("trailStep", typeof(RectTransform), typeof(Image));

            _track.transform.SetParent(transform);
            _track.GetComponent<RectTransform>().localPosition = Vector2.zero;
            _track.GetComponent<RectTransform>().localScale = Vector3.one;
            _track.GetComponent<RectTransform>().localRotation = Quaternion.identity;
            _track.GetComponent<Image>().sprite = Resources.Load<Sprite>("Trail/trailStep");
            _track.GetComponent<Image>().color = new Color(255, 255, 255, 0.3f);
            _tracks.Add(_track);
        }

        public override void OnDrag(PointerEventData eventData)
        {

            if (Input.touchCount >= 1)
            {
                angleX -= eventData.delta.x * _speed * Time.deltaTime;
                angleY = Mathf.Clamp(angleY -= eventData.delta.y * _speed * Time.deltaTime, -89, 89);
                //radius = Mathf.Clamp(radius -= Input.mouseScrollDelta.y, 1, 10);

                //if (angleX > 360)
                //{
                //    angleX -= 360;
                //}
                //else if (angleX < 0)
                //{
                //    angleX += 360;
                //}

                Vector3 orbit = Vector3.forward * radius;
                orbit = Quaternion.Euler(invertVector? angleY:-angleY, invertVector? angleX:-angleX, 0) * orbit;

                _camera.transform.position = _target.transform.position + orbit;
                _camera.transform.LookAt(_target.transform.position);

            }

            List<Touch> _touches = new List<Touch>();
            _touches.Clear();
            _touches = new List<Touch>(Input.touches);

            for (int i = 0; i < _touches.Count; i++)
            {
                if (i < _tracks.Count)
                {
                    float pointX = Input.touches[i].position.x - transform.GetComponent<RectTransform>().sizeDelta.x / 2;
                    float pointY = Input.touches[i].position.y - transform.GetComponent<RectTransform>().sizeDelta.y / 2;
                    _tracks[i].GetComponent<RectTransform>().localPosition = new Vector2(pointX, pointY);
                }
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            for (int i = _tracks.Count - 1; i >= 0; i--)
            {
                Destroy(_tracks[i]);
                _tracks.RemoveAt(i);
            }
        }
    }
}