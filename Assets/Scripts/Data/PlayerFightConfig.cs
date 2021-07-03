using UnityEngine;

namespace AI.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerFightConfig), menuName = "Configs/" + nameof(PlayerFightConfig), order = 0)]
    public class PlayerFightConfig : ScriptableObject
    {
        public int startMoney = 200;
        public int startHealth = 50;
        public int startPower = 20;
        public int startCrimeLevel = 2;
    }
}