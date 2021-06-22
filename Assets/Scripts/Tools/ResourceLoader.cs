using UnityEngine;

namespace MobileGame.Tools
{
    public static class ResourceLoader
    {
        public static GameObject LoadPrefab(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.PathResource);
        }
        
        public static T LoadObject<T>(ResourcePath path) where T : Object
        {
            return Resources.Load<T>(path.PathResource);
        }
        
        public static T InstantiateObject<T>(T prefab, Transform parent, bool worldPositionStays) where T : Object
        {
            return Object.Instantiate(prefab, parent, worldPositionStays);
        }
        
        public static T LoadAndInstantiateObject<T>(ResourcePath path, Transform parent, bool worldPositionStays) where T : Object
        {
            var prefab = LoadObject<T>(path);
            return InstantiateObject(prefab, parent, worldPositionStays);
        }
    }
}