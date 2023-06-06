using System;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class ShootingSoundAspect : MonoBehaviour, IShootingAspect
    {
        private AudioSource _soundSource;
        
        private void Awake()
        {
            _soundSource = GetComponent<AudioSource>();
        }

        public bool CheckIfAllowedToShoot()
        {
            return true;
        }

        public void ExecutePreShootRoutine()
        {
            _soundSource.Play();
        }

        public void ExecutePostShootRoutine()
        { }
    }
}