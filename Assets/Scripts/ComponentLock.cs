using System;
using UnityEngine;

namespace SpaceMadness
{
    public abstract class BaseComponentLock<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T linkedComponent;
        
        public void OnEnable()
        {
            if (linkedComponent != null)
            {
                linkedComponent.enabled = false;
            }
        }

        public void OnDisable()
        {
            if (linkedComponent != null)
            {
                linkedComponent.enabled = true;
            }
        }
    }
    
    public class ComponentLock : BaseComponentLock<MonoBehaviour> { };
}