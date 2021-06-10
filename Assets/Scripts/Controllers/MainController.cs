using System.Collections.Generic;
using MobileGame.Data.Items;
using MobileGame.Enums;
using MobileGame.Inventory;
using Platformer.Player;
using UnityEngine;

namespace MobileGame.Controllers
{
    public class MainController : BaseController
    {
        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemsConfigs)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            _itemsConfigs = itemsConfigs;
            
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        }

        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private InventoryController _inventoryController;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private List<ItemConfig> _itemsConfigs;

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
                    _inventoryController = new InventoryController(_itemsConfigs, _placeForUi);
                    _inventoryController.ShowInventory(() => { });
                    
                    _gameController = new GameController(_profilePlayer);
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
            _inventoryController?.Dispose();
            _gameController?.Dispose();
        }
    }
}