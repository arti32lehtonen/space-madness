using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class OnDeathActivator : MonoBehaviour, IOnDeathActivator
    {
        [SerializeField] private GameObject activatedObject;

        public void OnDeath()
        {
            if (activatedObject != null)
            {
                activatedObject.SetActive(true);
            }
        }
    }
}