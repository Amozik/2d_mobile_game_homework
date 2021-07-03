using System.Collections.Generic;
using MobileGame.Abilities;
using MobileGame.Data;
using MobileGame.Data.Items;
using MobileGame.Tools;
using Platformer.Player;
using UnityEngine;

namespace MobileGame.Controllers
{
    public class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, List<AbilityItemConfig> abilitiesConfigs, UiConfig uiConfig,
            Transform placeForUi)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
        
            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
        
            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            
            var carController = new CarController();
            AddController(carController);

            var abilityController = new AbilitiesController(abilitiesConfigs, carController, placeForUi);
            AddController(abilityController);
            abilityController.ShowAbilities();

            var uiController = new UiController(uiConfig, placeForUi, profilePlayer);
            AddController(uiController);
        }
    }
}