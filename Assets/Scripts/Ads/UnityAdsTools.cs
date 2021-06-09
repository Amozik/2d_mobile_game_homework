using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace MobileGame.Ads
{
    public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
#if UNITY_ANDROID
        private const string GAME_ID = "4159005";
        private const string REWARD_PlACMENT_ID = "Rewarded_Android";
        private const string INTERSTITIAL_PlACMENT_ID = "Interstitial_Android";
#elif  UNITY_IOS
        private string GAME_ID = "4159004";
        private string REWARD_PlACMENT_ID  = "Rewarded_iOS";
        private string INTERSTITIAL_PlACMENT_ID  = "Interstitial_iOS";
#endif
        
        private Action _callbackSuccessShowVideo;
      
        private void Start()
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(GAME_ID, true);
        }
        
        public void ShowInterstitial()
        {
            if (Advertisement.IsReady())
            {
                _callbackSuccessShowVideo = null;
                Advertisement.Show(INTERSTITIAL_PlACMENT_ID);
            }
            else
            {
                Debug.LogWarning("Interstitial ad not ready at the moment! Please try again later!");
            }
        }

        public void ShowVideo(Action successShow)
        {
            if (Advertisement.IsReady(REWARD_PlACMENT_ID))
            {
                _callbackSuccessShowVideo = successShow;
                Advertisement.Show(REWARD_PlACMENT_ID);
            }
            else
            {
                Debug.LogWarning("Interstitial ad not ready at the moment! Please try again later!");
            }
        }

        public void OnUnityAdsReady(string placementId)
        {
        }

        public void OnUnityAdsDidError(string message)
        {
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                    _callbackSuccessShowVideo?.Invoke();
                    break;
                case ShowResult.Skipped:
                    // Do not reward the user for skipping the ad.
                    break;
                case ShowResult.Failed:
                    Debug.LogWarning ("The ad did not finish due to an error.");
                    break;
            }
        }
        
        public void OnDestroy() {
            Advertisement.RemoveListener(this);
        }
    }
}