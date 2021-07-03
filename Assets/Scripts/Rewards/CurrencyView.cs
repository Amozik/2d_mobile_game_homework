using TMPro;
using UnityEngine;

namespace MobileGame.Rewards
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _currentCountCoin;
    
        [SerializeField] 
        private TMP_Text _currentCountFuel;

        public void UpdateCurrencies(int coins, int fuel)
        {
            _currentCountCoin.text = coins.ToString();
            _currentCountFuel.text = fuel.ToString();
        }
    }
}