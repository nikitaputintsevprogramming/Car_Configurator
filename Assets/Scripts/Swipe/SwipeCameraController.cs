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

        private float v;
        private float h;

        [SerializeField] List<GameObject> _tracks;
        DefaultControls.Resources knob;

        [SerializeField] private float angle;
        [SerializeField] private float radius = 10;
        [SerializeField] private float degreesPerSecond = 30;

        private void Start()
        {
            TimerDetector timerDetector = FindObjectOfType<TimerDetector>();
            timerDetector.OnActionTimerEnds += ActionTimerEnds;

            _camera.transform.position = _camStartPos;
            _camera.transform.LookAt(_target.position);
        }

        private void ActionTimerEnds(object sender, EventArgs e)
        {
            _presentation = true;
            Debug.Log("Режим презентации включен");
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
            Vector3 _moveTo = new Vector3(h * _speed * Time.deltaTime, 0, 0); //v * _speed * Time.deltaTime)
            Vector3 _rotTo = new Vector3(0, h * 100f * Time.fixedDeltaTime, 0);
            Vector3 _leanTo = new Vector3(-v * _speed * Time.deltaTime, 0, 0);

            v = eventData.delta.y;
            h = eventData.delta.x;

            //if (Input.touchCount >= 2)
            //{
            //_camera.transform.Rotate(Vector3.up, -h * 10f * Time.deltaTime, Space.World);
            //_camera.transform.LookAt(_target);
            //_camera.transform.Rotate(_leanTo, Space.Self);
            //}
            //else
            //{

            //}

            _camera.transform.RotateAround(_target.position, Vector3.up, h * _speed * Time.deltaTime);
            _camera.transform.RotateAround(_target.position, Vector3.right, v * _speed * Time.deltaTime);
            
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
            v = 0;
            h = 0;

            for (int i = _tracks.Count - 1; i >= 0; i--)
            {
                Destroy(_tracks[i]);
                _tracks.RemoveAt(i);
            }
        }

        private void KeybMove()
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
        }
    }
}