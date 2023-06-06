using System;
using UnityEngine;

namespace SpaceMadness
{
    public class InteractableSoundManager : MonoBehaviour
    {
        private AudioSource _selfSource;

        private void Awake()
        {
            _selfSource = GetComponent<AudioSource>();
        }

        public void PlaySoundOnInteraction()
        {
            _selfSource.Play();
        }
    }
}