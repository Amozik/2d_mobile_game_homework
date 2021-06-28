using System;
using UnityEngine;

namespace MobileGame.Rewards
{
    public class DailyRewardModel
    {
        private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
        private const string TimeGetRewardKey = nameof(TimeGetRewardKey);
        
        public int CurrentSlotInActive
        {
            get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
            set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
        }

        public DateTime? TimeGetReward
        {
            get
            {
                var data = PlayerPrefs.GetString(TimeGetRewardKey, null);
            
                if (!string.IsNullOrEmpty(data))
                    return DateTime.Parse(data);

                return null;
            }
            set
            {
                if (value != null)
                    PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(TimeGetRewardKey);
            }
        }

        public void ResetTimer()
        {
            PlayerPrefs.DeleteKey(CurrentSlotInActiveKey);
            PlayerPrefs.DeleteKey(TimeGetRewardKey);
        }
    }
}