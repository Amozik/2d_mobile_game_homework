using System.Collections.Generic;

namespace MobileGame.Interfaces.Items
{
    public interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}