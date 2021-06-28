using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MobileGame.Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] 
        private Button _buttonStart;
        
        [SerializeField] 
        private Button _buttonExit;
        
        public void Init(UnityAction startGame, UnityAction exitGame)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonExit.onClick.AddListener(exitGame);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }
    }
}