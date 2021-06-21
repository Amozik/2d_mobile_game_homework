using System.Collections.Generic;
using MobileGame.Interfaces.Items;

namespace MobileGame.Interfaces.Inventory
{
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnEquipItem(IItem item);
    }

}