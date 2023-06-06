using System;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class ShootingAnimationAspect : MonoBehaviour, IShootingAspect
    {
        private Animator _selfAnimator;
        private static readonly int IsShooting = Animator.StringToHash("IsShooting");

        public void Awake()
        {
            _selfAnimator = GetComponentInParent<Animator>();
        }

        public bool CheckIfAllowedToShoot()
        {
            return true;
        }

        public void ExecutePreShootRoutine()
        {
            _selfAnimator.SetTrigger(IsShooting);
        }

        public void ExecutePostShootRoutine() { }
    }
}