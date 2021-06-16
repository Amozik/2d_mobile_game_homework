using MobileGame.Data.Items;
using MobileGame.Interfaces.Abilities;

namespace MobileGame.Abilities
{
    public class OilAbility : IAbility
    {
        private readonly AbilityItemConfig _config;

        public OilAbility(AbilityItemConfig config)
        {
            _config = config;
        }
        
        public void Apply(IAbilityActivator activator)
        {
            //не придумал, что доллжно делать масло
        }
    }
}