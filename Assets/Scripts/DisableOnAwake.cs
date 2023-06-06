using System;
using UnityEngine;

namespace SpaceMadness
{
    public class DisableOnAwake : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}