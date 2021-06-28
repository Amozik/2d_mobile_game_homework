using MobileGame.Ads;
using MobileGame.Analytic;
using MobileGame.Enums;
using MobileGame.Tools;
using UnityEngine;

namespace Platformer.Player
{
    public class ProfilePlayer
    {
        private const string CoinKey = nameof(CoinKey);
        private const string FuelKey = nameof(FuelKey);
        
        public SubscriptionProperty<GameState> CurrentState { get; }
        
        //TODO Возможно переделать на SubscriptionProperty
        public int Coins { 
            get => PlayerPrefs.GetInt(CoinKey, 0);
            private set => PlayerPrefs.SetInt(CoinKey, value);
        }
        public int Fuel { 
            get => PlayerPrefs.GetInt(FuelKey, 0);
            private set => PlayerPrefs.SetInt(FuelKey, value); 
        }

        public Car CurrentCar { get; }
        
        public IAnalyticTools AnalyticTools { get; }
        
        public IAdsShower AdsShower { get; }
        
        public ProfilePlayer(float speedCar, IAdsShower adsShower)
        {
            AdsShower = adsShower;
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = new UnityAnalyticTools();
        }

        public void AddCoins(int value)
        {
            Coins += value;
        }
        
        public void AddFuel(int value)
        {
            Fuel += value;
        }
    }
}