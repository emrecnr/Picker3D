using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private float3 _firstPosition;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _firstPosition = transform.position;
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CameraSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void OnReset()
    {
        transform.position = _firstPosition;
    }

    private void OnSetCameraTarget()
    {
        //var player = FindObjectOfType<PlayerManager>().transform;
        //virtualCamera.Follow = player;
        // virtualCamera.LookAt = player;
    }

    private void UnSubscribeEvents()
    {
        CameraSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
