using UnityEngine;

namespace Core.Configs
{
    /// <summary>
    /// Config file for game
    /// </summary>
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Core/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private float _initialDropTime;
        [SerializeField] private float _dropSpeedFactor;
        [SerializeField] private float _minimalDropTime;
        [SerializeField] private float _linePerLevelThreshold;
        
        public float InitialDropTime => _initialDropTime;
        public float LinePerLevelThreshold => _linePerLevelThreshold;
        public float DropSpeedFactor => _dropSpeedFactor;
        public float MinimalDropTime => _minimalDropTime;
    }
}