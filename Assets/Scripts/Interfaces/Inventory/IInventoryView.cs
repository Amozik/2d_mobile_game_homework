using System;
using System.Collections.Generic;
using MobileGame.Interfaces.Items;

namespace MobileGame.Interfaces.Inventory
{
    public interface IInventoryView
    {
        Action<IItem> Selected { get; set; }
        Action<IItem> Deselected { get; set; }
        void Display(IReadOnlyList<IItem> items);
        void UnDisplay();
    }

}