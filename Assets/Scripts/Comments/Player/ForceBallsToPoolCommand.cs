using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using Managers;
using UnityEngine;

namespace Comments.Player
{
    public class ForceBallsToPoolCommand : MonoBehaviour
    {
        private PlayerManager _manager;
        private PlayerForceData _forceData;
        public ForceBallsToPoolCommand(PlayerManager manager, PlayerForceData forceData)
        {
            _manager = manager;
            _forceData = forceData;
        }

        public void Execute()
        {
            
        }
    }
}
