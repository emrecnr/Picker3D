using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using UnityEngine;

namespace Name
{    
    [CreateAssetMenu(fileName = "CD_Player", menuName = "Picker3D/CD_Player", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerData Data;
    }
}
