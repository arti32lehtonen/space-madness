using System;
using UnityEngine;

namespace SpaceMadness
{
    public class GamePauseActivator : MonoBehaviour
    {
        public void OnEnable()
        {
            Time.timeScale = 0f;
        }

        public void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}