using System.Collections.Generic;
using MobileGame.Rewards;
using UnityEngine;

namespace MobileGame.Data.Rewards
{
    [CreateAssetMenu(fileName = nameof(DailyRewardsConfig),  menuName = "Configs/" + nameof(DailyRewardsConfig), order = 0)]
    public class DailyRewardsConfig : ScriptableObject
    {
        public DailyRewardView view;
        
        [Header("Settings Time Get Reward")]
        public float timeCooldown = 86400;
  
        public float timeDeadline = 172800;
  
        [Header("Settings Rewards")]
        public List<Reward> rewards;
    }
}