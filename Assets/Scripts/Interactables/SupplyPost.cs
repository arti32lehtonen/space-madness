using SpaceMadness.DamageSystem;
using SpaceMadness.InteractionSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceMadness.Interactables
{
    public class SupplyPost : BaseInteractable
    {
        public bool restoreFullSupply = true;
        public int restoredAmount = 0;
        
        public override void ExecuteInteraction(GameObject interactorObject)
        {
            var supplyComponent = interactorObject.GetComponentInChildren<LimitedSupplyAspect>();
            if (supplyComponent == null)
            {
                return;
            }
            
            if (restoreFullSupply)
            {
                var maxSupply = supplyComponent.GetMaxValue();
                var currentSupply = supplyComponent.GetCurrentValue();
                supplyComponent.ChangeCurrentValue(maxSupply - currentSupply);
            }
            else
            {
                supplyComponent.ChangeCurrentValue(restoredAmount);
            }
        }

        public override bool CheckIfAvailable(GameObject interactorObject)
        {
            return interactorObject.GetComponentInChildren<LimitedSupplyAspect>() != null;
        }
    }
}