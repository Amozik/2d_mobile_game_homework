using System.Collections.Generic;
using MobileGame.Controllers;
using MobileGame.Data.Items;
using MobileGame.Interfaces;
using MobileGame.Interfaces.Upgrades;

namespace MobileGame.Upgrades
{
    public class UpgradeHandlersRepository : BaseController, IRepository<int, IUpgradeCarHandler>
    {
        public IReadOnlyDictionary<int, IUpgradeCarHandler> Collection => _upgradeItemsMapById;
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
                    return new SpeedUpgradeCarHandler(config.value, config.view);
                case UpgradeType.Control:
                    return new TiresUpgradeCarHandler(config.value, config.view);
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }
    }
}