using System;
using UnityEngine;

namespace StatsSystem
{
    [Serializable]
    public class Stat
    {
        [field: SerializeField] public StatType StatType { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
        
        public Stat(StatType statType, float value)
        {
            StatType = statType;
            Value = value;
        }

        public Stat GetCopy()
        {
            return new Stat(StatType, Value);
        }

        public void SetStatValue(float value) => Value = value;
        
        public static implicit operator float(Stat stat) => stat.Value;
    }
}