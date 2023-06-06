using System;
using UnityEngine;

namespace SpaceMadness.UI
{
    public class MenuSlideAnimationProvider : MonoBehaviour
    {
        private Animator _selfAnimator;

        public void Awake()
        {
            _selfAnimator = GetComponent<Animator>();
        }

        public void RunAnimation(bool isActive)
        {
            _selfAnimator.SetBool("IsActive", !isActive);
        }
        
    }
}