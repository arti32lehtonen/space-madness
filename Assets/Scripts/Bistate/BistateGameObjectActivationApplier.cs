using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class BistateGameObjectActivationApplier : MonoBehaviour, IBistateStateApplier
    {
        public void ApplyBeforeTransition(bool newState)
        {
            if (newState)
            {
                gameObject.SetActive(true);
            }
        }

        public void ApplyAfterTransition(bool newState)
        {
            if (!newState)
            {
                gameObject.SetActive(false);
            }
        }
    }
}