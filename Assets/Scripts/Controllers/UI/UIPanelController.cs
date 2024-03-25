using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Signals;
using UnityEngine;

namespace Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<Transform> layers = new List<Transform>();

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanel += OnCloseAllPanel;
        }

        private void OnCloseAllPanel()
        {
            foreach (Transform layer in layers)
            {
                if (layer.childCount <= 0) return;
                Destroy(layer.GetChild(0).gameObject);
            }
        }

        private void OnOpenPanel(UIPanelTypes panelType, int layerIndex)
        {
            OnClosePanel(layerIndex);
            Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"), layers[layerIndex]);
        }

        private void OnClosePanel(int layerIndex)
        {
            if (layers[layerIndex].childCount <= 0) return;
            Destroy(layers[layerIndex].GetChild(0).gameObject);
        }

        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanel -= OnCloseAllPanel;
        }

        private void OnDisable()
        {

        }
    }
}
