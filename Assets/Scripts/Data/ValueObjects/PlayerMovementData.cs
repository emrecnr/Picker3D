using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObjects
{
    [Serializable]
    public struct PlayerMovementData
    {
        public float ForwardSpeed;
        public float SidewaySpeed;
    }
}
