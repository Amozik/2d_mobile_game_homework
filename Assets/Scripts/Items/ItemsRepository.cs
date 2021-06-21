using System.Collections.Generic;
using MobileGame.Controllers;
using MobileGame.Data.Items;
using MobileGame.Interfaces.Items;

namespace MobileGame.Items
{
    public class ItemsRepository : BaseController, IItemsRepository
    {
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
    
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
        {
            PopulateItems(upgradeItemConfigs);
        }
  
        protected override void OnDispose()
        {
            _itemsMapById.Clear();
            _itemsMapById = null;
        }

        private void PopulateItems(List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (_itemsMapById.ContainsKey(config.id)) 
                    continue;
            
                _itemsMapById.Add(config.id, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                Id = config.id,
                Info = new ItemInfo { Title = config.title }
            };
        }
    }
}