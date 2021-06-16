﻿using System;
using System.Collections.Generic;
using MobileGame.Controllers;
using MobileGame.Data.Items;
using MobileGame.Interfaces.Abilities;

namespace MobileGame.Abilities
{
    public class AbilityRepository : BaseController, IAbilityRepository
    {
        public IReadOnlyDictionary<int, IAbility> AbilityMapByItemId => _abilityMapByItemId;
        
        private Dictionary<int, IAbility> _abilityMapByItemId = new Dictionary<int, IAbility>();

        public AbilityRepository(List<AbilityItemConfig> abilityConfigs)
        {
            PopulateItems(abilityConfigs);
        }
        
        private void PopulateItems(List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (_abilityMapByItemId.ContainsKey(config.Id)) 
                    continue;
            
                _abilityMapByItemId.Add(config.Id, CreateAbility(config));
            }
        }

        private IAbility CreateAbility(AbilityItemConfig config)
        {
            switch (config.type)
            {
                case AbilityType.Gun:
                    return new GunAbility(config);
                case AbilityType.Oil:
                    return new OilAbility(config);
                case AbilityType.Acceleration:
                    return new AccelerationAbility(config);
                    break;
                default:
                    return StubAbility.Default;
            }
        }
    }
}