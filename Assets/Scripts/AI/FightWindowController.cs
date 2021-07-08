using AI.Data;
using AI.Enemies;
using AI.Player;
using MobileGame.Controllers;
using MobileGame.Enums;
using Platformer.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MobileGame.AI
{
    public class FightWindowController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private FightWindowView _fightWindowView;
        private PlayerFightController _playerFightController;
        private Enemy _enemy;

        public FightWindowController(FightWindowView view, PlayerFightConfig playerFightConfig, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _playerFightController = new PlayerFightController(playerFightConfig);
            AddController(_playerFightController);
            
            _enemy = new Enemy("my enemy");
            _playerFightController.AttachEnemy(_enemy);

            _fightWindowView = Object.Instantiate(view);
            AddGameObjects(_fightWindowView.gameObject);
            
            _fightWindowView.ChangeDataWindow += ChangeDataWindow;
            _fightWindowView.Fight += Fight;
            _fightWindowView.Pass += Pass;
            
            _fightWindowView.UpdatePlayerData(_playerFightController.Money, DataType.Money);
            _fightWindowView.UpdatePlayerData(_playerFightController.Health, DataType.Health);
            _fightWindowView.UpdatePlayerData(_playerFightController.Power, DataType.Power);
            _fightWindowView.UpdatePlayerData(_playerFightController.Crime, DataType.Crime);
            _fightWindowView.UpdateEnemyData(_enemy.Power);
            
            _fightWindowView.SetPassVisibility(_playerFightController.Crime > 2);
        }
        
        private void Fight()
        {
            Debug.Log(_playerFightController.Power >= _enemy.Power
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }
        
        private void Pass()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }

        private void ChangeDataWindow(int value, DataType dataType)
        {
            _playerFightController.ChangeData(value, dataType, OnChange);

            void OnChange(int changedValue)
            {
                _fightWindowView.UpdatePlayerData(changedValue, dataType);
                
                if (dataType == DataType.Crime)
                {
                    _fightWindowView.SetPassVisibility(changedValue > 2);
                }
            }
            
            _fightWindowView.UpdateEnemyData(_enemy.Power);
        }

        protected override void OnDispose()
        {
            _fightWindowView.Fight -= Fight;
            _fightWindowView.Pass -= Pass;
            
            _playerFightController.DetachEnemy(_enemy);
            
            base.OnDispose();
        }
    }
}