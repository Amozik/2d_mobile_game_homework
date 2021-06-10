using System;
using System.Collections.Generic;
using MobileGame.Interfaces.Items;

namespace MobileGame.Interfaces.Inventory
{
    public interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(IReadOnlyList<IItem> items);
        void UnDisplay();
    }

}