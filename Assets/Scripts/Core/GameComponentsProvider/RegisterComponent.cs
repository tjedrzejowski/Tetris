using UnityEngine;

namespace Core.GameComponentsProvider
{
    /// <summary>
    /// Automatically registers a specified MonoBehaviour component into the given ComponentProvider on Awake.
    /// Connecting scene-based components to the global service locator at runtime.
    /// </summary>
    public class RegisterComponent : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _component;
        [SerializeField] private ComponentsProvider _provider;

        public void Awake()
        {
            var type = _component.GetType();
            _provider.RegisterComponent(type, _component);
        }
    }
}