using System.Collections.Generic;
using MobileGame.Abilities;
using MobileGame.Data.Items;
using MobileGame.Enums;
using MobileGame.Inventory;
using Platformer.Player;
using UnityEngine;

namespace MobileGame.Controllers
{
    public class MainController : BaseController
    {
        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private GarageController _garageController;
        private AbilitiesController _abilityController;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private List<UpgradeItemConfig> _itemsConfigs;
        private List<AbilityItemConfig> _abilitiesConfigs;

        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<UpgradeItemConfig> itemsConfigs, List<AbilityItemConfig> abilitiesConfigs)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            _itemsConfigs = itemsConfigs;
            _abilitiesConfigs = abilitiesConfigs;

            OnChangeGameState(_profilePlayer.CurrentState.Value);
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        }

        protected override void OnDispose()
        {
            ClearAll();
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
            base.OnDispose();
        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _garageController = new GarageController(_itemsConfigs, _profilePlayer.CurrentCar, _placeForUi);
                    _garageController.Enter();

                    _gameController = new GameController(_profilePlayer, _abilitiesConfigs, _placeForUi);
                    _mainMenuController?.Dispose();
                    break;
                default:
                    ClearAll();
                    break;
            }
        }
        
        private void ClearAll()
        {
            _mainMenuController?.Dispose();
            _garageController?.Dispose();
            _gameController?.Dispose();
        }
    }
}