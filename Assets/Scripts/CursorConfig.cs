using System;
using UnityEngine;

namespace SpaceMadness
{
    [CreateAssetMenu(fileName = "CursorConfig", menuName = "CursorConfig", order = 0)]
    public class CursorConfig : ScriptableObject
    {
        public Texture2D baseCursor;
        public Texture2D interactAllowCursor;
        public Texture2D interactForbidCursor;
        
        public Texture2D GetImageBasedOnState(CursorState state)
        {
            Texture2D cursorImage;
            switch (state)
            {
                case CursorState.Base:
                    cursorImage = baseCursor;
                    break;
                case CursorState.InteractAllow:
                    cursorImage = interactAllowCursor;
                    break;
                case CursorState.InteractForbid:
                    cursorImage = interactForbidCursor;
                    break;
                default:
                    throw new InvalidOperationException("Unrecognized cursor state");
            }

            return cursorImage;
        }

        
    }
}