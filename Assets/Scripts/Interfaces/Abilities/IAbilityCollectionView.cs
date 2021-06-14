using System;
using System.Collections.Generic;
using MobileGame.Interfaces.Items;

namespace MobileGame.Interfaces.Abilities
{
    public interface IAbilityCollectionView
    {
        event Action<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}