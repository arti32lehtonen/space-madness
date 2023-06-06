using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public enum InteractionState
    {
        Allow,
        Forbid,
        None
    }
    
    public interface IInteractionProvider
    {
        InteractionState CheckInteractionState();
        GameObject GetLinkedObject();
    }
}