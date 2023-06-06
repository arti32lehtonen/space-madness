using UnityEngine;

namespace SpaceMadness
{
    public class DestroyAfterAnimation : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator,
            AnimatorStateInfo stateInfo, int layerIndex)
        {
            var animatorObject = animator.gameObject;
            animatorObject.GetComponent<SpriteRenderer>().sprite = null;
            Destroy(animatorObject);
        }
    }
}