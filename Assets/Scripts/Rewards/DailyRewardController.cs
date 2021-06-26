using System;
using System.Collections;
using System.Collections.Generic;
using MobileGame.Controllers;
using MobileGame.Data.Rewards;
using Platformer.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MobileGame.Rewards
{
    public class DailyRewardController: BaseController
    {
        public Action OnGetReward;
        
        private DailyRewardView _dailyRewardView;
        private DailyRewardModel _dailyRewardModel;
        private readonly ProfilePlayer _profilePlayer;
        
        private readonly List<Reward> _rewards;
        private readonly float _timeCooldown;
        private readonly float _timeDeadline;
        private bool _isGetReward;

        public DailyRewardController(DailyRewardsConfig config, ProfilePlayer profilePlayer, Transform placeForUi)
        {
            _rewards = config.rewards;
            _timeCooldown = config.timeCooldown;
            _timeDeadline = config.timeDeadline;
            _profilePlayer = profilePlayer;
            
            _dailyRewardModel = new DailyRewardModel();
            _dailyRewardView = Object.Instantiate(config.view, placeForUi, false);;
            AddGameObjects(_dailyRewardView.gameObject);
            _dailyRewardView.Init(_rewards, _timeCooldown,  ClaimReward, ResetTimer);
        }
        
        public void Display()
        {
            _dailyRewardView.CloseAction += UnDisplay;
            _dailyRewardView.StartCoroutine(RewardsStateUpdater());
            _dailyRewardView.Show();
        }
        
        public void UnDisplay()
        {
            _dailyRewardView.CloseAction -= UnDisplay;
            _dailyRewardView.StopCoroutine(RewardsStateUpdater());
            _dailyRewardView.Hide();
        }
        
        private IEnumerator RewardsStateUpdater()
        {
            while (true)
            {
                RefreshRewardsState();
                yield return new WaitForSeconds(1);
            }
        }
        
        private void RefreshRewardsState()
        {
            _isGetReward = true;

            if (_dailyRewardModel.TimeGetReward.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _dailyRewardModel.TimeGetReward.Value;

                if (timeSpan.Seconds > _timeDeadline)
                {
                    _dailyRewardModel.TimeGetReward = null;
                    _dailyRewardModel.CurrentSlotInActive = 0;
                }
                else if (timeSpan.Seconds < _timeCooldown)
                {
                    _isGetReward = false;
                }
            }

            _dailyRewardView.RefreshRewards(_dailyRewardModel.TimeGetReward, _isGetReward, _dailyRewardModel.CurrentSlotInActive);
        }
        
        private void ClaimReward()
        {
            if (!_isGetReward)
                return;

            var reward = _rewards[_dailyRewardModel.CurrentSlotInActive];

            switch (reward.rewardType)
            {
                case RewardType.Coin:
                    _profilePlayer.AddCoins(reward.countCurrency);
                    break;
                case RewardType.Fuel:
                    _profilePlayer.AddFuel(reward.countCurrency);
                    break;
            }
            
            OnGetReward?.Invoke();

            _dailyRewardModel.TimeGetReward = DateTime.UtcNow;
            _dailyRewardModel.CurrentSlotInActive = (_dailyRewardModel.CurrentSlotInActive + 1) % _rewards.Count;

            RefreshRewardsState();
        }

        private void ResetTimer()
        {
            _dailyRewardModel.ResetTimer();
        }
    }
}