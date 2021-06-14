using System;
using MobileGame.Data.Items;
using MobileGame.Interfaces.Abilities;
using MobileGame.Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MobileGame.Abilities
{
    public class GunAbility : IAbility
    {
        private readonly AbilityItemConfig _abilityConfig;
        private readonly Rigidbody2D _viewPrefab;
        private GameObject _abilityView;

        public GunAbility(AbilityItemConfig abilityConfig)
        {
            _abilityConfig = abilityConfig;
            _viewPrefab = ResourceLoader.LoadPrefab(new ResourcePath {PathResource = "Prefabs/cannonBomb"}).GetComponent<Rigidbody2D>();
            if (_viewPrefab == null) 
                throw new InvalidOperationException($"{nameof(GunAbility)} view requires {nameof(Rigidbody2D)} component!");
            _abilityView = Object.Instantiate(abilityConfig.view);
        }
        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_viewPrefab, _abilityView.transform);
            projectile.AddForce(activator.GetViewObject().transform.right * _abilityConfig.value, ForceMode2D.Force);
        }
    }
}