using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.GameComponentProvider
{
    [CreateAssetMenu(fileName = "ComponentProvider", menuName = "Core/ComponentProvider")]
    public class ComponentProvider : ScriptableObject
    {
        private readonly Dictionary<Type, object> _components = new();

        public IEnumerable<object> RegisteredComponents => _components.Values;

        public void RegisterComponent<T>(T component)
        {
            var type = typeof(T);
            if (_components.TryAdd(type, component))
            {
                Debug.LogError($"ComponentProvider.Register: Service of type {type.FullName} already registered");
            }
        }

        public T GetComponent<T>() where T : class
        {
            var type = typeof(T);
            if (_components.TryGetValue(type, out var component))
            {
                return component as T;
            }

            throw new ArgumentException($"ServiceLocator.GetService: Service of type {type.FullName} is not registered");
        }

        public bool TryGetComponent<T>(out T component) where T : class
        {
            var type = typeof(T);
            if (_components.TryGetValue(type, out var componentObject))
            {
                component = componentObject as T;
                return true;
            }

            component = default;
            return false;
        }
    }
}