using UnityEngine;

namespace MobileGame.Data.Items
{
    public enum UpgradeType
    {
        None,
        Speed,
        Control
    }

    [CreateAssetMenu(fileName = nameof(UpgradeItemConfig),  menuName = "Configs/" + nameof(UpgradeItemConfig), order = 0)]
    public class UpgradeItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public UpgradeType type;
        public float value;

        public int Id => itemConfig.id;
    }
}