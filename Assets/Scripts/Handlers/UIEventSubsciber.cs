using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Handlers
{
    public class UIEventSubsciber : MonoBehaviour
    {
        [SerializeField] private UIEventSubscriptionTypes type;
        private Button _button;
        private UIManager _uiManager;

        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _button = GetComponent<Button>();
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                    _button.onClick.AddListener(_uiManager.Play);
                    break;

                case UIEventSubscriptionTypes.OnNextLevel:
                    _button.onClick.AddListener(_uiManager.NextLevel);
                    break;

                case UIEventSubscriptionTypes.OnRestartLevel:
                    _button.onClick.AddListener(_uiManager.RestartLevel);
                    break;
            }
        }

        private void UnSubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                    _button.onClick.RemoveListener(_uiManager.Play);
                    break;

                case UIEventSubscriptionTypes.OnNextLevel:
                    _button.onClick.RemoveListener(_uiManager.NextLevel);
                    break;

                case UIEventSubscriptionTypes.OnRestartLevel:
                    _button.onClick.RemoveListener(_uiManager.RestartLevel);
                    break;
            }
        }
    }
}
