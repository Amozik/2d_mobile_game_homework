using UnityEngine;

namespace MobileGame.Data.Items
{
    public enum AbilityType
    {
        None,
        Gun,
        Oil,
        Acceleration,
    }

    [CreateAssetMenu(fileName = nameof(AbilityItemConfig),  menuName = "Configs/" + nameof(AbilityItemConfig), order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public GameObject view;
        public AbilityType type;
        public float value;
        public int Id => itemConfig.id;
    }
}