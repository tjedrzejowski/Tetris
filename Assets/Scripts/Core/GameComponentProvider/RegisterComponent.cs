using UnityEngine;

namespace Core.GameComponentProvider
{
    public class RegisterComponent : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _component;
        [SerializeField] private ComponentProvider _provider;

        public void Awake()
        {
            var type = _component.GetType();
            _provider.RegisterComponent(type, _component);

            foreach (var component in _provider.RegisteredComponents)
                Debug.Log($"RegisteredComponent: {component.GetType().FullName}");
        }
    }
}