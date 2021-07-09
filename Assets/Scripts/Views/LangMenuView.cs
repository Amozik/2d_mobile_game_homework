using System;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Views
{
    public class LangMenuView : AnimatedWindow
    {
        [SerializeField] 
        private Button _buttonEn;
        
        [SerializeField] 
        private Button _buttonRu;

        [SerializeField] 
        private Button _closeButton;
        
        public Action CloseAction { get; set; }

        public void Init(Action<string> changeLanguage)
        {
            _buttonEn.onClick.AddListener(() => changeLanguage("en"));
            _buttonRu.onClick.AddListener(() => changeLanguage("ru"));
            _closeButton.onClick.AddListener(() => CloseAction?.Invoke());
        }

        private void OnDisable()
        {
            _buttonEn.onClick.RemoveAllListeners();
            _buttonRu.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}