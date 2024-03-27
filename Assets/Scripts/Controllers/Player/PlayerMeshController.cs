using System;
using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        [SerializeField] private new Renderer renderer;
        [SerializeField] private TextMeshProUGUI scaleText;
        [SerializeField] private ParticleSystem confetti;

        private PlayerMeshData _data;

        
        internal void SetData(PlayerMeshData meshData)
        {
            _data = meshData;
        }

        internal void ScaleUpPlayer()
        {
            renderer.gameObject.transform.DOScaleX(_data.ScaleCounter,1).SetEase(Ease.Flash);
        }

        internal void ScaleUpText()
        {
            scaleText.DOFade(1,0).SetEase(Ease.Flash).OnComplete(()=>{
                scaleText.DOFade(0,.3f).SetDelay(.35f);
                scaleText.rectTransform.DOAnchorPosY(1f,.65f).SetEase(Ease.Linear);
            });
        }

        internal void PlayConfetti()
        {
            confetti.Play();
        }

        internal void OnReset()
        {
            renderer.gameObject.transform.DOScaleX(1,1);
        }
    }
}
