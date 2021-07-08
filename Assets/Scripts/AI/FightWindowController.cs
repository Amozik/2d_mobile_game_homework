using System.Diagnostics;
using AI.Data;
using AI.Enemies;
using AI.Player;
using MobileGame.Controllers;
using MobileGame.Enums;
using MobileGame.Notifications;
using Platformer.Player;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Debug = UnityEngine.Debug;

namespace MobileGame.AI
{
    public class FightWindowController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private FightWindowView _fightWindowView;
        private PlayerFightController _playerFightController;
        private Enemy _enemy;

        private Stopwatch _watchLoadPrefab;
        
        public FightWindowController(AssetReference view, PlayerFightConfig playerFightConfig, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _playerFightController = new PlayerFightController(playerFightConfig);
            AddController(_playerFightController);
            
            _enemy = new Enemy("my enemy");
            _playerFightController.AttachEnemy(_enemy);

            _watchLoadPrefab = Stopwatch.StartNew();
            
            var asyncOperationHandle = Addressables.InstantiateAsync(view);

            asyncOperationHandle.Completed += OnViewLoaded;
        }

        private void OnViewLoaded(AsyncOperationHandle<GameObject> asyncOperationHandle)
        {
            _fightWindowView = asyncOperationHandle.Result.GetComponent<FightWindowView>();
            _fightWindowView.ChangeDataWindow += ChangeDataWindow;
            _fightWindowView.Fight += Fight;
            _fightWindowView.Pass += Pass;

            _fightWindowView.UpdatePlayerData(_playerFightController.Money, DataType.Money);
            _fightWindowView.UpdatePlayerData(_playerFightController.Health, DataType.Health);
            _fightWindowView.UpdatePlayerData(_playerFightController.Power, DataType.Power);
            _fightWindowView.UpdatePlayerData(_playerFightController.Crime, DataType.Crime);
            _fightWindowView.UpdateEnemyData(_enemy.Power);

            _fightWindowView.SetPassVisibility(_playerFightController.Crime > 2);
            
            _watchLoadPrefab.Stop();
            Debug.Log($"Load prefab time {_watchLoadPrefab.ElapsedMilliseconds}ms");
        }
        
        private void Fight()
        {
            if (_playerFightController.Power >= _enemy.Power)
            {
                NotificationsService.Instance.Send("Fight Win!!!", Color.green);
            }
            else
            {
                NotificationsService.Instance.Send("Fight Loose :(", Color.red);
            }
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

            Addressables.ReleaseInstance(_fightWindowView.gameObject);
            
            base.OnDispose();
        }
    }
}