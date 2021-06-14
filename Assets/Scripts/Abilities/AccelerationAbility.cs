using MobileGame.Data.Items;
using MobileGame.Interfaces.Abilities;

namespace MobileGame.Abilities
{
    public class AccelerationAbility : IAbility
    {
        private AbilityItemConfig _config;

        public AccelerationAbility(AbilityItemConfig config)
        {
            _config = config;
        }

        public void Apply(IAbilityActivator activator)
        {
            //TODO на время ускорить машинку
        }
    }
}