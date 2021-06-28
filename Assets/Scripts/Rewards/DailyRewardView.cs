using System;
using System.Collections.Generic;
using DG.Tweening;
using MobileGame.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MobileGame.Rewards
{
    public class DailyRewardView : MonoBehaviour
    {
        private const float SHOW_ANIMATION_DURATION = 0.3f;
        
        [SerializeField] 
        private TMP_Text _timerNewReward;
    
        [SerializeField] 
        private Transform _targetRewards;

        [SerializeField] 
        private ContainerSlotRewardView _containerSlotRewardView;
    
        [SerializeField] 
        private Button _getRewardButton;
    
        [SerializeField] 
        private Button _resetButton;
        
        [SerializeField] 
        private Button _closeButton;

        [SerializeField] 
        private ProgressBar _progressBar;
        
        public Action CloseAction { get; set; }
        
        private List<Reward> _rewards;
        private List<ContainerSlotRewardView> _slots;
        private float _timeCooldown;
        private CanvasGroup _canvasGroup;
        
        public void Init(List<Reward> rewards, float timeCooldown, UnityAction claimReward, UnityAction resetTimer)
        {
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
            SetupCanvasGroup(false);
            
            _rewards = rewards;
            _timeCooldown = timeCooldown;
            _slots = new List<ContainerSlotRewardView>();

            for (var i = 0; i < _rewards.Count; i++)
            {
                var instanceSlot = GameObject.Instantiate(_containerSlotRewardView, _targetRewards, false);
                instanceSlot.SetData(_rewards[i], i + 1, false);

                _slots.Add(instanceSlot);
            }
            
            _getRewardButton.onClick.AddListener(claimReward);
            _resetButton.onClick.AddListener(resetTimer);
            _closeButton.onClick.AddListener(() => CloseAction?.Invoke());
            
            transform.localScale = Vector3.zero;
        }

        public void RefreshRewards(DateTime? timeGetReward, bool isGetReward, int currentSlotInActive)
        {
            _getRewardButton.interactable = isGetReward;

            if (isGetReward)
            {
                _timerNewReward.text = "The reward is received today";
            }
            else
            {
                if (timeGetReward != null)
                {
                    var nextClaimTime = timeGetReward.Value.AddSeconds(_timeCooldown);
                    var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                    var timeGetRewardText = $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";
        
                    _timerNewReward.text = $"Time to get the next reward: {timeGetRewardText}";
                    _progressBar.CurrentValue = (float) (currentClaimCooldown.TotalSeconds / _timeCooldown);
                }
            }

            for (var i = 0; i < _slots.Count; i++)
                _slots[i].SetData(_rewards[i],i + 1, i == currentSlotInActive);
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
        
        private void OnDestroy()
        {
            _getRewardButton.onClick.RemoveAllListeners();
            _resetButton.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();
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