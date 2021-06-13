using System.Collections.Generic;
using MobileGame.Interfaces.Inventory;
using MobileGame.Interfaces.Items;
using UnityEngine;

namespace MobileGame.Inventory
{
    public class InventoryModel : IInventoryModel
    {
        private readonly List<IItem> _items = new List<IItem>();
    
        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _items;
        }

        public void EquipItem(IItem item)
        {
            if (_items.Contains(item)) 
                return;
            
            _items.Add(item);
            Debug.Log($"{item.Info.Title} equipped");
        }

        public void UnEquipItem(IItem item)
        {
            if (!_items.Contains(item)) 
                return;
            
            _items.Remove(item);
            Debug.Log($"{item.Info.Title} unequipped");
        }
    }
}