using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class BistateSingleAnimatedTransitionProvider : 
        MonoBehaviour, IBistateTransitionProvider
    {
        private Animator _selfAnimator;
        private static readonly int IsOn = Animator.StringToHash("IsOn");
        private bool _isDuringTransition = false;
        
        public void Awake()
        {
            _selfAnimator = GetComponent<Animator>();
        }

        public void StartTransition(bool newState)
        {
            if (_selfAnimator.GetBool(IsOn) != newState)
            {
                _selfAnimator.SetBool(IsOn, newState);
                _isDuringTransition = true;
            }
        }

        public bool CheckIfDuringTransition()
        {
            return _isDuringTransition;
        }

        /// <summary>
        /// Method can be used by any StateMachineBehaviour class, which support animation.
        /// Otherwise, there will be endless transition process.
        /// Don't use this method for anything else! 
        /// </summary>
        /// <param name="transitionState">False, if no transition animation is performed</param>
        internal void SetTransitionState(bool transitionState)
        {
            _isDuringTransition = transitionState;
        }
    }
}