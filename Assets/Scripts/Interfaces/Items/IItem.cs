using MobileGame.Items;

namespace MobileGame.Interfaces.Items
{
    public interface IItem
    {
        int Id { get; }
        ItemInfo Info { get; }
    }
}