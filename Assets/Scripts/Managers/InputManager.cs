using System;
using System.Collections.Generic;
using Data.UnityObjects;
using Data.ValueObjects;
using Keys;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private InputData _inputData;
        private bool _isAvailableForTouch, _isFirstTimeTouchTaken, _isTouching;

        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;

        private void Awake()
        {
            _inputData = GetInputData();
        }

        private InputData GetInputData()
        {
            return Resources.Load<CD_Input>("Data/CD_Input").Data;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
            InputSignals.Instance.onEnableInput += OnEnableInput;
            InputSignals.Instance.onDisableInput += OnDisableInput;
        }

        private void OnDisableInput()
        {
            throw new NotImplementedException();
        }

        private void OnEnableInput()
        {
            throw new NotImplementedException();
        }

        private void OnReset()
        {
            _isAvailableForTouch = false;
            // _isFirstTimeTouchTaken = false;
            _isTouching = false;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onReset = OnReset;
            InputSignals.Instance.onEnableInput -= OnEnableInput;
            InputSignals.Instance.onDisableInput -= OnDisableInput;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void Update()
        {
            if (!_isAvailableForTouch) return;

            if (Input.GetMouseButtonUp(0) && !IsPointerOverUIElement())
            {
                _isTouching = false;
                InputSignals.Instance.onInputReleased?.Invoke();
            }

            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIElement())
            {
                _isTouching = true;
                InputSignals.Instance.onInputTaken?.Invoke();
                _mousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && !IsPointerOverUIElement())
            {
                if (_isTouching)
                {
                    if (_mousePosition != null)
                    {
                        Vector2 mouseDeltaPosition = (Vector2)Input.mousePosition - _mousePosition.Value;

                        if (mouseDeltaPosition.x > _inputData.HorizontalInputSpeed)
                        {
                            _moveVector.x = _inputData.HorizontalInputSpeed / 10f * mouseDeltaPosition.x;
                        }
                        else if (mouseDeltaPosition.x < -_inputData.HorizontalInputSpeed)
                        {
                            _moveVector.x = -_inputData.HorizontalInputSpeed / 10f * -mouseDeltaPosition.x;
                        }
                        else
                        {
                            _moveVector.x = Mathf.SmoothDamp(_moveVector.x,0,  ref _currentVelocity,_inputData.ClampSpeed);
                        }

                        _mousePosition = Input.mousePosition;
                        InputSignals.Instance.onInputDragged?.Invoke(new HorizontalInputParams(){ HorizontalValue = _moveVector.x, ClampValues = _inputData.ClampValues });
                    }

                }
            }
        }

        private bool IsPointerOverUIElement()
        {
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData,results);
            return results.Count > 0;
        }
    }
}