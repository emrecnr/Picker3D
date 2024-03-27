using System.Collections;
using System.Collections.Generic;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        private const string StageArea = "StageArea";
        private const string FinishArea= "FinishArea";

        private void OnTriggerEnter(Collider other) 
        {
            if(other.CompareTag(StageArea))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();

                // Stage area control
            }   

            if(other.CompareTag(FinishArea))
            {
                CoreGameSignals.Instance.onFinishAreaSuccessful?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }

            // mini game
        }

        internal void OnReset()
        {
            
        }
    }
}
