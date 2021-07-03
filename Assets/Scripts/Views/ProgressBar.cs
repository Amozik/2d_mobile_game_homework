using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Views
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        public Text _displayText;
        
        private float _currentValue = 0f;
        public float CurrentValue {
            get {
                return _currentValue;
            }
            set {
                _currentValue = value;
                _slider.value = _currentValue;
                _displayText.text = (_slider.value * 100).ToString("0.00") + "%";
            }
        }
    }
}