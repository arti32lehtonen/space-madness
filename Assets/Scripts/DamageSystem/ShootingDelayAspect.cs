using System.Collections;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class ShootingDelayAspect : MonoBehaviour, IShootingAspect
    {
        [SerializeField] private float delay = 1.0f;
        private bool _isAllowed = true;
        
        public bool CheckIfAllowedToShoot()
        {
            return _isAllowed;
        }

        public void ExecutePreShootRoutine()
        {
            return;
        }

        public void ExecutePostShootRoutine()
        {
            StartCoroutine(ApplyDelay());
        }

        private IEnumerator ApplyDelay()
        {
            _isAllowed = false;
            yield return new WaitForSeconds(delay);
            _isAllowed = true;
        }
        
    }
}