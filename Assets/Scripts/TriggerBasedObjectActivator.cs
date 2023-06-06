using System;
using UnityEngine;

namespace SpaceMadness
{
    public class TriggerBasedObjectActivator : MonoBehaviour
    {
        [SerializeField] private GameObject linkedObject;
        [SerializeField] private bool activateOnlyOnce = true;
        
        private Collider2D _selfCollider;
        private bool _activated = false;
        
        public void Awake()
        {
            _selfCollider = GetComponent<Collider2D>();
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!_activated)
            {
                linkedObject.SetActive(true);
            }

            if (activateOnlyOnce)
            {
                _activated = true;
            }
        }
    }
}