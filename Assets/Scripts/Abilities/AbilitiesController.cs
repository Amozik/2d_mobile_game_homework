using System.Collections.Generic;
using System.Linq;
using MobileGame.Controllers;
using MobileGame.Data.Items;
using MobileGame.Interfaces.Abilities;
using MobileGame.Interfaces.Items;
using MobileGame.Items;
using MobileGame.Tools;
using UnityEngine;

namespace MobileGame.Abilities
{
    public class AbilitiesController : BaseController, IAbilitiesController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/abilities"};
        private readonly AbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;
        private readonly ItemsRepository _abilityItemsRepository;

        public AbilitiesController(List<AbilityItemConfig> abilityItemConfigs, IAbilityActivator abilityActivator, Transform placeForUi)
        {
            _abilityRepository = new AbilityRepository(abilityItemConfigs);
            AddController(_abilityRepository);
            _abilityItemsRepository = new ItemsRepository(abilityItemConfigs.Select(value => value.itemConfig).ToList());
            AddController(_abilityItemsRepository);

            _abilityCollectionView = LoadView(placeForUi);
            _abilityActivator = abilityActivator;
            
            SubscribeView();
        }

        private AbilityCollectionView LoadView(Transform placeForUi)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
        
            return objectView.GetComponent<AbilityCollectionView>();
        }
        
        public void ShowAbilities()
        {
            _abilityCollectionView.Display(_abilityItemsRepository.Collection.Values.ToList());
        }
        
        private void OnAbilityUseRequested(IItem e)
        {
            if (_abilityRepository.Collection.TryGetValue(e.Id, out var ability))
                ability.Apply(_abilityActivator);
        }

        private void SubscribeView()
        {
            _abilityCollectionView.UseRequested += OnAbilityUseRequested;
        }
        
        private void UnSubscribeView()
        {
            _abilityCollectionView.UseRequested -= OnAbilityUseRequested;
        }

        protected override void OnDispose()
        {
            UnSubscribeView();
            base.OnDispose();
        }
    }
}