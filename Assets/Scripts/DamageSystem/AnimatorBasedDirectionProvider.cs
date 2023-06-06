using System;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class AnimatorBasedDirectionProvider : MonoBehaviour, IShootingDirectionProvider
    {
        private Animator _selfAnimator;
        private static readonly int LastHorizontalHash = 
            Animator.StringToHash("LastHorizontal");
        private static readonly int LastVerticalHash = 
            Animator.StringToHash("LastVertical");

        public void Awake()
        {
            _selfAnimator = GetComponentInParent<Animator>();
        }

        public Vector3 GetShootingDirection()
        {
            var lastHorizontal = _selfAnimator.GetFloat(LastHorizontalHash);
            var lastVertical = _selfAnimator.GetFloat(LastVerticalHash);

            Vector3 viewDirection;
            
            if (Mathf.Abs(lastHorizontal) > Mathf.Abs(lastVertical))
            {
                viewDirection = lastHorizontal > 0 ? 
                    new Vector3(1, 0, 0) :
                    new Vector3(-1, 0, 0);
            }
            else
            {
                viewDirection = lastVertical > 0 ? 
                    new Vector3(0, 1, 0) :
                    new Vector3(0, -1, 0);
            }

            return viewDirection;
        }
    }
}