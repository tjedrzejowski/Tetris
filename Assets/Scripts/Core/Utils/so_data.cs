using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Utils
{
    [CreateAssetMenu(fileName = "Ability", menuName = "Tetris/Data")]
    public class AbilityData : ScriptableObject
    {
        public string Label;
        [SerializeReference] public List<EffectData> effects;
    }

    [Serializable]
    public abstract class EffectData
    {
        public abstract void Execute();
    }

    [Serializable]
    public class TestEffect_1 : EffectData
    {
        public int amount;
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }

    [Serializable]
    public class TestEffect_2 : EffectData
    {
        public int value;
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}