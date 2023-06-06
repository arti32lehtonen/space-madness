using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class DamagingPlatform : MonoBehaviour
    {
        [SerializeField] private float standardDelay = 1.0f;
        [SerializeField] private int damage = 1;
        [SerializeField] private bool struckAfterWalkingOff = true;
        
        private Dictionary<IDamageable, IEnumerator> _damagedObjectsDelayedProcesses = 
            new Dictionary<IDamageable, IEnumerator>();
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            var damagedObject = col.GetComponent<IDamageable>();
            if (damagedObject == null)
            {
                return;
            }

            var damageCoroutine = DelayedDamage(damagedObject);
            _damagedObjectsDelayedProcesses[damagedObject] = damageCoroutine;
            StartCoroutine(damageCoroutine);
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            var damagedObject = col.GetComponent<IDamageable>();
            if (damagedObject == null)
            {
                return;
            }

            if (!struckAfterWalkingOff)
            {
                StopCoroutine(_damagedObjectsDelayedProcesses[damagedObject]);
            }
            _damagedObjectsDelayedProcesses.Remove(damagedObject);
        }

        private IEnumerator DelayedDamage(IDamageable damagingObject)
        {
            yield return new WaitForSeconds(standardDelay);
            // it means that object have not been destroyed yet
            if (damagingObject != null)
            {
                bool isDestroyed = damagingObject.GetDamage(damage);
                if (!isDestroyed)
                {
                    if (_damagedObjectsDelayedProcesses.ContainsKey(damagingObject))
                    {
                        var damageCoroutine = DelayedDamage(damagingObject);
                        _damagedObjectsDelayedProcesses[damagingObject] = damageCoroutine;
                        StartCoroutine(damageCoroutine);
                    }
                }
            }
        }
    }
}