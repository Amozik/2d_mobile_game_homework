using System;
using DG.Tweening;
using UnityEngine;

namespace MobileGame.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class AnimatedWindow : MonoBehaviour
    {
        private const float SHOW_ANIMATION_DURATION = 0.3f;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
            SetupCanvasGroup(false);
        }
        
        public void Show()
        {
            SetupCanvasGroup(true);
            AnimationShow();
        }

        public void Hide()
        {
            AnimationHide(() => SetupCanvasGroup(false));
        }
        
        private void SetupCanvasGroup(bool value)
        {
            _canvasGroup.alpha = value ? 1 : 0;
            _canvasGroup.interactable = value;
            _canvasGroup.blocksRaycasts = value;
        }
        
        private void AnimationShow()
        {
            var sequence = DOTween.Sequence();
      
            sequence.Insert(0.0f, transform.DOScale(Vector3.one, SHOW_ANIMATION_DURATION));
            sequence.OnComplete(() =>
            {
                sequence = null;
            });
        }
        
        private void AnimationHide(Action onComplete)
        {
            var sequence = DOTween.Sequence();
      
            sequence.Insert(0.0f, transform.DOScale(Vector3.zero, SHOW_ANIMATION_DURATION));
            sequence.OnComplete(() =>
            {
                sequence = null;
                onComplete?.Invoke();
            });
        }
    }
}