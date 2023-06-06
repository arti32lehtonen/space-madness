using System;
using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        private InteractableSoundManager _soundManager;
        
        public void Awake()
        {
            _soundManager = GetComponent<InteractableSoundManager>();
        }

        public void Interact(GameObject interactorObject)
        {
            if (_soundManager != null)
            {
                _soundManager.PlaySoundOnInteraction();
            }
            
            ExecuteInteraction(interactorObject);
        }

        public abstract void ExecuteInteraction(GameObject interactorObject);
        public abstract bool CheckIfAvailable(GameObject interactorObject);
    }
}