﻿using System.Collections.Generic;
using MobileGame.Controllers;
using MobileGame.Data.Items;
using MobileGame.Interfaces.Upgrades;

namespace MobileGame.Upgrades
{
    public class UpgradeHandlersRepository : BaseController
    {
        public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;
        private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();
        
        public UpgradeHandlersRepository(List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(upgradeItemConfigs);
        }
  
        protected override void OnDispose()
        {
            _upgradeItemsMapById.Clear();
            _upgradeItemsMapById = null;
        }

        private void PopulateItems(List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (_upgradeItemsMapById.ContainsKey(config.Id))
                    continue;
                _upgradeItemsMapById.Add(config.Id, CreateHandlerByType(config));
            }
        }

        private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeCarHandler(config.value);
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }
    }
}