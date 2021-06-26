using System;
using UnityEngine;

namespace MobileGame.Rewards
{
    [Serializable]
    public class Reward
    {
        public RewardType rewardType;
        public Sprite iconCurrency;
        public int countCurrency;
    }
}