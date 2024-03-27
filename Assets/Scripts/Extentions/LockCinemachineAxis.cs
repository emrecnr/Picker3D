using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Extentions
{
    [ExecuteInEditMode]
    [SaveDuringPlay]
    [AddComponentMenu("")]
    public class LockCinemachineAxis : CinemachineExtension
    {
        [Tooltip("Lock the Cinemachine Virtual Camera's X axis position with this specific value")]
        public float XClampValue = 0;

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if(stage == CinemachineCore.Stage.Body)
            {
                var position = state.RawPosition;
                position.x = XClampValue;
                state.RawPosition = position;
            }
        }
    }
}
