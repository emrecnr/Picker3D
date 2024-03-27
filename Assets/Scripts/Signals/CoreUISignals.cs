using System.Collections;
using System.Collections.Generic;
using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreUISignals : MonoSingleton<CoreUISignals>
    {

        public UnityAction<UIPanelTypes,int> onOpenPanel = delegate {};
        public UnityAction<int> onClosePanel = delegate {};
        public UnityAction onCloseAllPanel = delegate {};
    }
}
