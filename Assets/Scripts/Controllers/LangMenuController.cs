using System.Collections;
using MobileGame.Tools;
using MobileGame.Views;
using Platformer.Player;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace MobileGame.Controllers
{
    public class LangMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/langMenu"};

        private readonly ProfilePlayer _profilePlayer;
        private readonly LangMenuView _view;
        
        public LangMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(ChangeLanguage);

            _view.StartCoroutine(SetPlayerLang());
        }
        
        private LangMenuView LoadView(Transform placeForUi)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
        
            return objectView.GetComponent<LangMenuView>();
        }

        public void Display()
        {
            _view.CloseAction += UnDisplay;
            _view.Show();
        }
        
        public void UnDisplay()
        {
            _view.CloseAction -= UnDisplay;
            _view.Hide();
        }
        
        private IEnumerator SetPlayerLang()
        {
            yield return LocalizationSettings.InitializationOperation;
            
            ChangeLanguage(_profilePlayer.Lang);
        }
        
        private void ChangeLanguage(string code)
        {
            _profilePlayer.Lang = code;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(code);
        }
    }
}