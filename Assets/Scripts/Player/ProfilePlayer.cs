using MobileGame.Enums;
using MobileGame.Tools;

namespace Platformer.Player
{
    public class ProfilePlayer
    {
        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
        }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }
    }
}