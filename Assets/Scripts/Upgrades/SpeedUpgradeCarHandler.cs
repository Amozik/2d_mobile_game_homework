using MobileGame.Interfaces.Upgrades;
using UnityEngine;

namespace MobileGame.Upgrades
{
    public class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        private readonly float _speed;
        private GameObject _view;
        
        public SpeedUpgradeCarHandler(float speed, GameObject view)
        {
            _speed = speed;
            _view = view;
        }
        
        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            if (_view != null)
                Object.Instantiate(_view);
            
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }

    }
}