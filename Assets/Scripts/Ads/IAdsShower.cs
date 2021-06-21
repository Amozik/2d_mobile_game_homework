using System;

namespace MobileGame.Ads
{
    public interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}