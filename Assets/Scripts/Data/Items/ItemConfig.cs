using UnityEngine;

namespace MobileGame.Data.Items
{
    [CreateAssetMenu(fileName = nameof(ItemConfig),  menuName = "Configs/" + nameof(ItemConfig), order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public int id;
        public string title;
    }
}