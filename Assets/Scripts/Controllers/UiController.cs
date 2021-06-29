using MobileGame.Data;
using MobileGame.Enums;
using MobileGame.Rewards;
using Platformer.Player;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Controllers
{
    public class UiController : BaseController
    {
        private CurrencyView _currencyView;
        
        private ProfilePlayer _profilePlayer;
        private DailyRewardController _dailyRewardController;
        
        private Button _dailyRewardButton;
        private Button _startFightButton;

        public UiController(UiConfig uiConfig, Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            
            _currencyView = Object.Instantiate(uiConfig.currencyView, placeForUi, false);
            AddGameObjects(_currencyView.gameObject);
            _currencyView.UpdateCurrencies(profilePlayer.Coins, profilePlayer.Fuel);
            
            _dailyRewardButton = Object.Instantiate(uiConfig.dailyRewardButton, placeForUi, false);

            _dailyRewardController = new DailyRewardController(uiConfig.dailyRewardsConfig, profilePlayer, placeForUi);
            AddController(_dailyRewardController);
            _dailyRewardController.OnGetReward += UpdateCurrencies;
            
            _dailyRewardButton.onClick.AddListener(_dailyRewardController.Display);
            
            _startFightButton = Object.Instantiate(uiConfig.startFightButton, placeForUi, false);
            _startFightButton.onClick.AddListener(StartFight);
        }

        private void UpdateCurrencies()
        {
            _currencyView.UpdateCurrencies(_profilePlayer.Coins, _profilePlayer.Fuel);
        }

        private void StartFight()
        {
            _profilePlayer.CurrentState.Value = GameState.Fight;
        }

        protected override void OnDispose()
        {
            _dailyRewardController.OnGetReward -= UpdateCurrencies;
            
            _dailyRewardButton.onClick.RemoveAllListeners();
            _startFightButton.onClick.RemoveAllListeners();
            
            base.OnDispose();
        }
    }
}