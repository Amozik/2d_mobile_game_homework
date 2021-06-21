using System;
using System.Collections.Generic;
using MobileGame.Interfaces.Abilities;
using MobileGame.Interfaces.Items;
using MobileGame.Tools;
using UnityEngine;

namespace MobileGame.Abilities
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        [SerializeField] 
        private Transform _targetItems;

        public event Action<IItem> UseRequested;
        
        private readonly ResourcePath _abilityViewPath = new ResourcePath {PathResource = "Prefabs/abilityItem"};
        private IReadOnlyList<IItem> _abilityItems;
        private List<AbilityItemView> _abilytiesViiewCollection = new List<AbilityItemView>();
        
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            _abilityItems = abilityItems;

            foreach (var abilityItem in abilityItems)
            {
                var abilityView = Instantiate(ResourceLoader.LoadPrefab(_abilityViewPath), _targetItems, false);

                var abilityItemView = abilityView.GetComponent<AbilityItemView>();
                abilityItemView.Init(abilityItem, UseRequested);
                
                _abilytiesViiewCollection.Add(abilityItemView);
            }
        }
    }
}