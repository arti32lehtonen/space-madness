using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class ShootingReduceMovingBehaviour : StateMachineBehaviour
    {
        private IMovable _linkedMovable;
        [SerializeField] private float _speedOnShooting = 0.01f;
        
        public override void OnStateEnter(Animator animator,
            AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_linkedMovable == null)
            {
                _linkedMovable = animator.gameObject.GetComponent<IMovable>();
            }
            _linkedMovable.ChangeSpeed(_speedOnShooting, true);
        }

        public override void OnStateExit(Animator animator,
            AnimatorStateInfo stateInfo, int layerIndex)
        {
            _linkedMovable.ChangeSpeed(1, true);
        }
    }
}