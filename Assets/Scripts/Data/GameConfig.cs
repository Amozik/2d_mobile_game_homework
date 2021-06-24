using System.Collections.Generic;
using MobileGame.Data.Items;
using UnityEngine;

namespace MobileGame.Data
{
    [CreateAssetMenu(fileName = nameof(GameConfig),  menuName = "Configs/" + nameof(GameConfig), order = 0)]
    public class GameConfig : ScriptableObject
    {
        public UiConfig uiConfig;
        
        public List<UpgradeItemConfig> itemsConfigs;
        
        public List<AbilityItemConfig> abilitiesConfigs;
    }
}