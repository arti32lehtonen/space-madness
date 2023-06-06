using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class BistateNoAnimatedTransitionProvider : MonoBehaviour, IBistateTransitionProvider
    {
        public void StartTransition(bool newState)
        {
            return;
        }

        public bool CheckIfDuringTransition()
        {
            return false;
        }
    }
}