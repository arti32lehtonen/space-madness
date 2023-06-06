using UnityEngine;

namespace SpaceMadness
{
    public class Initializer : MonoBehaviour
    {
        public bool cursorIsDisabled = true;
        
        public void Awake ()
        {
            if (cursorIsDisabled)
            {
                CursorManager.Instance.SetCursorState(CursorState.None);
            }
            else
            {
                CursorManager.Instance.SetCursorState(CursorState.Base);
            }
            //QualitySettings.vSyncCount = 0;  // VSync must be disabled 
            //Application.targetFrameRate = 60;
        }
    }
}