using SpaceMadness.InteractionSystem;
using UnityEngine;

namespace SpaceMadness.Interactables
{
    public class RemoteInteractableActivator : BaseInteractable
    {
        [SerializeField] private GameObject relatedGameObject;
        [SerializeField] bool useOnlyOnce = false;
        private bool _used = false;
        
        public override void ExecuteInteraction(GameObject interactorObject)
        {
            _used = true;
            relatedGameObject.SetActive(true);
        }

        public override bool CheckIfAvailable(GameObject interactorObject)
        {
            if (useOnlyOnce)
            {
                return !_used;
            }

            return true;
        }
    }
}