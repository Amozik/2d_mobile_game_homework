using MobileGame.Interfaces.Items;

namespace MobileGame.Items
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public ItemInfo Info { get; set; }
    }

}