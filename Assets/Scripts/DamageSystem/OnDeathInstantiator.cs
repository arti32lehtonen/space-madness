using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class OnDeathInstantiator : MonoBehaviour, IOnDeathActivator
    {
        [SerializeField] private GameObject prefab;

        public void OnDeath()
        {
            var newObject = Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}