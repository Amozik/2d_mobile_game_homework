using MobileGame.Interfaces.Abilities;
using MobileGame.Tools;
using MobileGame.Views;
using UnityEngine;

namespace MobileGame.Controllers
{
    public class CarController : BaseController, IAbilityActivator
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/car"};
        private readonly CarView _carView;

        public CarController()
        {
            _carView = LoadView();
        }

        private CarView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
        
            return objView.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    }
}