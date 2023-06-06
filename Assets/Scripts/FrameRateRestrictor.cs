using System;
using UnityEngine;

namespace SpaceMadness
{
    public class FrameRateRestrictor : MonoBehaviour
    {
        [SerializeField] private int targetFrameRate;
        
        private void Awake()
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}