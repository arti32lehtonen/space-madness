using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class SetTransitionStateAfterAnimation : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator,
            AnimatorStateInfo stateInfo, int layerIndex)
        {
            var animationProvider  = 
                animator.gameObject.GetComponent<BistateSingleAnimatedTransitionProvider>();
            animationProvider.SetTransitionState(false);
        }
    }
}