using System.Collections.Generic;
using MobileGame.Controllers;
using MobileGame.Enums;
using Platformer.Player;
using UnityEngine;

namespace MobileGame
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] 
        private Transform _placeForUi;

        private MainController _mainController;

        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(15f);
            profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, profilePlayer);
            
            profilePlayer.AnalyticTools.SendMessage("load_game", new Dictionary<string, object>
            {
                {"time", Time.realtimeSinceStartup},
            });
        }

        protected void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}