using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class InteractableContainer : MonoBehaviour, IInteractable
    {
        public void Interact(GameObject interactorObject)
        {
            Debug.Log("InteractableContainer");
        }

        public bool CheckIfAvailable(GameObject interactorObject)
        {
            return true;
        }
    }
}