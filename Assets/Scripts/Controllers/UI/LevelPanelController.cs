using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField] private List<Image> stageImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue += OnSetLevelValue;
            UISignals.Instance.onSetStageColor += OnSetStageColor;
        }

        private void OnSetStageColor(byte stageValue)
        {
            stageImages[stageValue].material.DOColor(Color.yellow,.5f); // 777as7da7sd

            
        }

        private void OnSetLevelValue(byte levelValue)
        {
            var additinalValue = ++levelValue;

            levelTexts[0].text = additinalValue.ToString();

            additinalValue++;

            levelTexts[1].text = additinalValue.ToString();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue -= OnSetLevelValue;
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}
