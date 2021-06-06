﻿using MobileGame.Analytic;
using MobileGame.Enums;
using MobileGame.Tools;

namespace Platformer.Player
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }
        
        public IAnalyticTools AnalyticTools { get; set; }
        
        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = new UnityAnalyticTools();
        }
    }
}