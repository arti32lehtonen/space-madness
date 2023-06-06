using System;
using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class ObjectActivationInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        public void OnAllowInteraction(GameObject linkedObject)
        {
            SceneMainVariables.Instance.hintsCanvas.gameObject.SetActive(true);
        }

        public void OnForbidInteraction(GameObject linkedObject)
        {
            OnStopInteraction(linkedObject);
        }

        public void OnStopInteraction(GameObject linkedObject)
        {
            SceneMainVariables.Instance.hintsCanvas.gameObject.SetActive(false);
        }
    }
}