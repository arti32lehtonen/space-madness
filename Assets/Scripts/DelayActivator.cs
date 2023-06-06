using System;
using System.Collections;
using UnityEngine;

namespace SpaceMadness
{
    public class DelayActivator : MonoBehaviour
    {
        [SerializeField] private float timeDelay;
        [SerializeField] private GameObject linkedObject;

        public void Awake()
        {
            StartCoroutine(ActivateAfterTime(timeDelay));
        }

        private IEnumerator ActivateAfterTime(float delay)
        {
            yield return new WaitForSeconds(delay);
            linkedObject.SetActive(true);
        }
    }
}