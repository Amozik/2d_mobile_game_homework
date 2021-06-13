using MobileGame.Interfaces.Upgrades;

namespace MobileGame.Upgrades
{
    public class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        private readonly float _speed;
        
        public SpeedUpgradeCarHandler(float speed)
        {
            _speed = speed;
        }
        
        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }

    }
}