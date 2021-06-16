using System;

namespace MobileGame.Interfaces.Inventory
{
    public interface IInventoryController
    {
        void ShowInventory(Action callback);
        void HideInventory();
    }

}