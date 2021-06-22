using MobileGame.Data.Items;
using MobileGame.Interfaces.Abilities;
using MobileGame.Views;
using UnityEngine;

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
            var viewObject = activator.GetViewObject();
            viewObject.GetComponent<CarView>().Accelerate();
        }
    }
}