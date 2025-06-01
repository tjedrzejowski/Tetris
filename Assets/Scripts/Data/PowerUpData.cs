using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "Tetris/PowerUp")]
    public class PowerUpData : ScriptableObject
    {
        [field: SerializeField] public string Label { get; private set; }
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}