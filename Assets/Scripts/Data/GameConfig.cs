using System.Collections.Generic;
using AI.Data;
using MobileGame.Data.Items;
using UnityEngine;

namespace MobileGame.Data
{
    [CreateAssetMenu(fileName = nameof(GameConfig),  menuName = "Configs/" + nameof(GameConfig), order = 0)]
    public class GameConfig : ScriptableObject
    {
        public UiConfig uiConfig;
        
        public PlayerFightConfig playerFightConfig;
        
        public List<UpgradeItemConfig> itemsConfigs;
        
        public List<AbilityItemConfig> abilitiesConfigs;
    }
}