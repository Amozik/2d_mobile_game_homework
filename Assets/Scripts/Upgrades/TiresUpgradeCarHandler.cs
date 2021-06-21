using MobileGame.Interfaces.Upgrades;
using UnityEngine;

namespace MobileGame.Upgrades
{
    public class TiresUpgradeCarHandler : IUpgradeCarHandler
    {
        private readonly float _control;
        private GameObject _view;
        
        public TiresUpgradeCarHandler(float control, GameObject view)
        {
            _control = control;
            _view = view;
        }
        
        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            if (_view != null)
                Object.Instantiate(_view);

            return upgradableCar;
        }

    }
}