using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMeshData MeshData;
        public PlayerMovementData MovementData;
        public PlayerForceData ForceData;
    }
}
