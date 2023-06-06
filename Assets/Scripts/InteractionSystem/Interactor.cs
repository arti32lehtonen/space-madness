using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class Interactor : MonoBehaviour, IInteractor
    {
        private IInteractionProvider _interactionProvider;
        private IInteractionResponse[] _interactionResponses;
        private GameObject _linkedObject;

        public void Awake()
        {
            
            _interactionResponses = GetComponents<IInteractionResponse>();
            _interactionProvider = GetComponent<IInteractionProvider>();
        }
        
        public void RequestInteraction(bool isTryingToInteract)
        {
            var state = _interactionProvider.CheckInteractionState();
            if (state != InteractionState.None)
            {
                var newLinkedObject = _interactionProvider.GetLinkedObject();
                if (_linkedObject != null && _linkedObject != newLinkedObject)
                {
                    StopInteraction();
                }
                _linkedObject = newLinkedObject;

                if (state == InteractionState.Allow)
                {
                    AllowInteraction();
                    if (isTryingToInteract)
                    {
                        RunInteraction();
                        ForbidInteraction();
                    }
                }
                else
                {
                    ForbidInteraction();
                }
            }
            else
            {
                StopInteraction();
            }
        }

        private void AllowInteraction()
        {
            foreach (var interactionResponse in _interactionResponses)
            {
                interactionResponse.OnAllowInteraction(_linkedObject);
            }
        }

        private void RunInteraction()
        {
            var interactable = _linkedObject.GetComponent<IInteractable>();
            interactable.Interact(gameObject);
        }

        private void ForbidInteraction()
        {
            if (_linkedObject == null)
            {
                return;
            }
            
            foreach (var interactionResponse in _interactionResponses)
            {
                interactionResponse.OnForbidInteraction(_linkedObject);
            }
        }

        private void StopInteraction()
        {
            if (_linkedObject != null)
            {
                foreach (var interactionResponse in _interactionResponses)
                {
                    interactionResponse.OnStopInteraction(_linkedObject);
                }
                _linkedObject = null;
            }

        }
        
        
        
    }
}