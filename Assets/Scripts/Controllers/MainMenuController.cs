﻿using System.Collections.Generic;
using MobileGame.Enums;
using MobileGame.Tools;
using MobileGame.Views;
using Platformer.Player;
using UnityEngine;

namespace MobileGame.Controllers
{
    public class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
        }
    
        private MainMenuView LoadView(Transform placeForUi)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
        
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            
            _profilePlayer.AdsShower.ShowInterstitial();
            
            _profilePlayer.AnalyticTools.SendMessage("start_game", new Dictionary<string, object>
            {
                {"time", Time.realtimeSinceStartup},
            });
        }
    }
}