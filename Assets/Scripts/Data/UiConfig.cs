﻿using MobileGame.AI;
using MobileGame.Data.Rewards;
using MobileGame.Rewards;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace MobileGame.Data
{
    [CreateAssetMenu(fileName = nameof(UiConfig),  menuName = "Configs/" + nameof(UiConfig), order = 0)]
    public class UiConfig : ScriptableObject
    {
        public AssetReference fightWindowView;
        public DailyRewardsConfig dailyRewardsConfig;
        public CurrencyView currencyView;
        public Button dailyRewardButton;
        public Button startFightButton;
    }
}