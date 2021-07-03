using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MobileGame.Extensions
{
    public enum AnimationButtonType
    {
        ChangeRotation,
        ChangePosition,
        ChangeScale,
    }
    
    public class CustomButton : Button
    {
        public static string ChangeButtonType => nameof(_animationButtonType);
        public static string CurveEase => nameof(_curveEase);
        public static string Duration => nameof(_duration);
  
        [SerializeField]
        private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
  
        [SerializeField]
        private Ease _curveEase = Ease.Linear;
  
        [SerializeField]
        private float _duration = 0.6f;
  
        private float _scale = 0.95f;
        private float _strength = 30.0f;
        private RectTransform _rectTransform;

        protected override void Awake()
        {
            base.Awake();

            _rectTransform = GetComponent<RectTransform>();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            ActivateAnimation();
        }

        private void ActivateAnimation()
        {
            switch (_animationButtonType)
            {
                case AnimationButtonType.ChangeRotation:
                    _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_curveEase);
                    break;
                case AnimationButtonType.ChangePosition:
                    _rectTransform.DOShakeAnchorPos(_duration, Vector2.one * _strength).SetEase(_curveEase);
                    break;
                case AnimationButtonType.ChangeScale:
                    _rectTransform.DOScale(_scale, _duration).SetLoops(2, LoopType.Yoyo).SetEase(_curveEase);
                    break;
            }
        }
    }

}