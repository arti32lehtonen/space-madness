using System;
using UnityEngine;

namespace SpaceMadness.Structures
{
    [Serializable]
    public class CountableFinite : ICountableFinite
    {
        [SerializeField] private int currentValue;
        [SerializeField] private int maxValue;
        
        public int GetCurrentValue()
        {
            return currentValue;
        }

        public int GetMaxValue()
        {
            return maxValue;
        }

        public void ChangeCurrentValue(int changeModifier)
        {
            currentValue = changeModifier < 0 ? 
                Mathf.Max(0, GetCurrentValue() + changeModifier) : 
                Mathf.Min(GetMaxValue(), GetCurrentValue() + changeModifier);
        }
    }
}