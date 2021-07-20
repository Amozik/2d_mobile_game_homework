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
        private Button _buttonLang;
        
        [SerializeField] 
        private Button _buttonExit;
        
        public void Init(UnityAction startGame, UnityAction exitGame, UnityAction showLangMenu)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonExit.onClick.AddListener(exitGame);
            _buttonLang.onClick.AddListener(showLangMenu);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
            _buttonLang.onClick.RemoveAllListeners();
        }
    }
}