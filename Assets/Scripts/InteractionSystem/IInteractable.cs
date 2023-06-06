using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public interface IInteractable
    {
        public void Interact(GameObject interactorObject);
        public bool CheckIfAvailable(GameObject interactorObject);
    }
}