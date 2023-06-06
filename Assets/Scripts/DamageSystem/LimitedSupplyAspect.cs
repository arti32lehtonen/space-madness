using System;
using SpaceMadness.Structures;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceMadness.DamageSystem
{
    public class LimitedSupplyAspect : MonoBehaviour, IShootingAspect, ICountableFinite
    {
        [SerializeField] private CountableFinite supplyAmount;
        [SerializeField] private BarDisplay linkedSupplyBar;

        public void Awake()
        {
            if (linkedSupplyBar != null)
            {
                linkedSupplyBar.UpdateBar(supplyAmount);
            }
        }

        public bool CheckIfAllowedToShoot()
        {
            if (supplyAmount.GetCurrentValue() == 0)
            {
                return false;
            }

            return true;
        }

        public void ExecutePreShootRoutine()
        {
            supplyAmount.ChangeCurrentValue(-1);
            if (linkedSupplyBar != null)
            {
                linkedSupplyBar.UpdateBar(supplyAmount);
            }
        }

        public void ExecutePostShootRoutine() { }

        public CountableFinite GetSupplyAmount()
        {
            return supplyAmount;
        }

        public int GetCurrentValue()
        {
            return supplyAmount.GetCurrentValue();
        }

        public int GetMaxValue()
        {
            return supplyAmount.GetMaxValue();
        }

        public void ChangeCurrentValue(int changeModifier)
        {
            supplyAmount.ChangeCurrentValue(changeModifier);
            if (linkedSupplyBar != null)
            {
                linkedSupplyBar.UpdateBar(supplyAmount);
            }
        }
    }
}