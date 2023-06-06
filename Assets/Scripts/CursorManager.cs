using System;
using UnityEngine;


namespace SpaceMadness
{
    public enum CursorState
    {
        Base,
        InteractAllow,
        InteractForbid,
        None
    }
    
    public class CursorManager : MonoBehaviour
    {
        public CursorConfig config = null;
        public static CursorManager Instance { get; private set;}
        
        public void Awake() 
        {
            // If there is an instance, and it's not me, delete myself.
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public static Vector2 GetCursorHotspot(Texture2D cursorImage)
        {
            return new Vector2 (cursorImage.width / 2f, cursorImage.height / 2f);
        }

        public void SetCursorState(CursorState state)
        {
            if (state == CursorState.None)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                return;
            } 
            
            var cursorImage = config.GetImageBasedOnState(state);
            var hotspot = GetCursorHotspot(cursorImage);
            Cursor.SetCursor(cursorImage, hotspot, CursorMode.Auto);
            Cursor.visible = true;
        }
    }
}