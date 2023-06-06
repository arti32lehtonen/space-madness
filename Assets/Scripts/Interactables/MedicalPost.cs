using SpaceMadness.DamageSystem;
using SpaceMadness.InteractionSystem;
using UnityEngine;

namespace SpaceMadness.Interactables
{
    public class MedicalPost : BaseInteractable
    {
        public bool restoreFullHealth = true;
        public int restoredHealthAmount = 0;
            
        public override void ExecuteInteraction(GameObject interactorObject)
        {
            var damageable = interactorObject.GetComponent<IDamageable>();
            if (damageable == null)
            {
                return;
            }

            var maxHitPoints = damageable.GetMaxValue();
            var currentHitPoints = damageable.GetCurrentValue();
            if (restoreFullHealth)
            {
                damageable.GetDamage(currentHitPoints - maxHitPoints);
            }
            else
            {
                damageable.GetDamage(-restoredHealthAmount);
            }
        }

        public override bool CheckIfAvailable(GameObject interactorObject)
        {
            return interactorObject.GetComponent<IDamageable>() != null;
        }
    }
}