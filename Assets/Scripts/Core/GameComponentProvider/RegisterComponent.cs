using UnityEngine;

namespace Core.GameComponentProvider
{
    public class RegisterComponent : MonoBehaviour
    {
        [SerializeField] private ComponentProvider _provider;

        public void Awake()
        {
            _provider.RegisterComponent(this);

            foreach (var component in _provider.RegisteredComponents)
                Debug.Log($"RegisteredComponent: {component.GetType().FullName}");
        }
    }
}