using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class CursorInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        public CursorManager cursorManager;
        
        public void OnAllowInteraction(GameObject linkedObject)
        {
            cursorManager.SetCursorState(CursorState.InteractAllow);
        }

        public void OnForbidInteraction(GameObject linkedObject)
        {
            cursorManager.SetCursorState(CursorState.InteractForbid);
        }

        public void OnStopInteraction(GameObject linkedObject)
        {
            cursorManager.SetCursorState(CursorState.Base);
        }
    }
}