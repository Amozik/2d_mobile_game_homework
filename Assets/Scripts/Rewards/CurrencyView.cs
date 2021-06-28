using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Rewards
{
    public class CurrencyView : MonoBehaviour
    {
        private const float CHANGE_TEXT_ANIMATION_DURATION = 2.5f;
        
        [SerializeField] 
        private Text _currentCountCoin;
    
        [SerializeField] 
        private Text _currentCountFuel;

        public void UpdateCurrencies(int coins, int fuel)
        {
            _currentCountCoin.DOText(coins.ToString(), CHANGE_TEXT_ANIMATION_DURATION).SetEase(Ease.OutCubic);
            _currentCountFuel.DOText(fuel.ToString(), CHANGE_TEXT_ANIMATION_DURATION).SetEase(Ease.OutCubic);
        }
    }
}