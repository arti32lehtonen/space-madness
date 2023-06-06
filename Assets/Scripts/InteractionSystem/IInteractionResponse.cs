using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public interface IInteractionResponse
    {
        public void OnAllowInteraction(GameObject linkedObject);
        public void OnForbidInteraction(GameObject linkedObject);
        public void OnStopInteraction(GameObject linkedObject);
    }
}