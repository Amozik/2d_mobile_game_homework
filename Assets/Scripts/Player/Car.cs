using MobileGame.Interfaces.Upgrades;

namespace Platformer.Player
{
    public class Car : IUpgradableCar
    {
        private readonly float _defaultSpeed;
        
        public float Speed { get; set; }
        
        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }
        
        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}