using System.Collections;
using System.Collections.Generic;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {

        public UnityAction<byte> onSetStageColor = delegate {}; 
        public UnityAction<byte> onSetLevelValue = delegate {};
        public UnityAction onPlay = delegate {}; 
    }
}
