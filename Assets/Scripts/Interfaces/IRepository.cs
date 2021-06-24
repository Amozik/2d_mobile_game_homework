using System.Collections.Generic;

namespace MobileGame.Interfaces
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey, TValue> Collection { get; }

    }
}