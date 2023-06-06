using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public static class InteractionUtils
    {
        public static bool CheckIfAllowedToInteract(
            Collider2D interactableCollider, 
            GameObject interactorObject)
        {
            if (interactableCollider == null)
            {
                return false;
            }

            var interactable = interactableCollider.GetComponent<IInteractable>();

            if (interactable == null)
            {
                return false;
            }

            return interactable.CheckIfAvailable(interactorObject);
        }
        
    }
}