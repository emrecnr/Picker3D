using System.Collections;
using System.Collections.Generic;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CameraSignals : MonoSingleton<CameraSignals>
    {
    
        public UnityAction onSetCameraTarget = delegate {};
    }

}