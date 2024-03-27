using System;
using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using Keys;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;

        private PlayerMovementData _data;
        private bool _isReadyToMove, _isReadyToPlay;
        private float _xValue;

        private float2 _clampValues;

        internal void SetData(PlayerMovementData movementData)
        {
            _data = movementData;
        }

        private void FixedUpdate()
        {
            if (!_isReadyToPlay)
            {
                StopPlayer();
                return;
            }

            if (_isReadyToMove)
            {
                MovePlayer();
            }
            else
            {
                StopPlayerHorizontally();
            }
        }

        private void MovePlayer()
        {
            var velocity = rigidbody.velocity;
            velocity = new Vector3(_xValue * _data.SidewaySpeed, velocity.y, _data.ForwardSpeed);
            rigidbody.velocity = velocity;
            var position1 = rigidbody.position;
            Vector3 position;
            position = new Vector3(Mathf.Clamp(position1.x, _clampValues.x, _clampValues.y),
            (position = rigidbody.position).y, position.z);
            rigidbody.position = position;
        }

        private void StopPlayerHorizontally()
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, _data.ForwardSpeed);
            rigidbody.angularVelocity = float3.zero;
        }

        private void StopPlayer()
        {
            rigidbody.velocity = float3.zero;
            rigidbody.angularVelocity = float3.zero;
        }

        internal void IsReadyToPlay(bool condition)
        {
            _isReadyToPlay  = condition;
        }

        internal void IsReadyToMove(bool condition)
        {
            _isReadyToMove = condition;
        }

        internal void UpdateInputParams(HorizontalInputParams inputParams)
        {
            _xValue = inputParams.HorizontalValue;
            _clampValues = inputParams.ClampValues;
        }

        internal void OnReset()
        {
            StopPlayer();
            _isReadyToMove = false;
            _isReadyToPlay = false;
        }
    }
}
