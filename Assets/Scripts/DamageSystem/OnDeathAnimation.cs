using System;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class OnDeathAnimation : MonoBehaviour, IOnDeathActivator
    {
        private Animator _selfAnimator;
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        private void Awake()
        {
            _selfAnimator = GetComponent<Animator>();
        }

        public void OnDeath()
        {
            _selfAnimator.SetBool(IsDead, true);
        }
    }
}