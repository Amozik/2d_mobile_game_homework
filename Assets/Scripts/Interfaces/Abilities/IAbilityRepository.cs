using System.Collections.Generic;

namespace MobileGame.Interfaces.Abilities
{
    public interface IAbilityRepository
    {
        IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
    }
}