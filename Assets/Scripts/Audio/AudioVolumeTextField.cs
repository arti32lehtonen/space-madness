using System;
using TMPro;
using UnityEngine;

namespace SpaceMadness.Audio
{
    public class AudioVolumeTextField : MonoBehaviour
    {
        [SerializeField] private string mixerTag;
        
        private TextMeshProUGUI _textComponent;
        
        private void Awake()
        {
            _textComponent = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            SyncTextComponentWithMixer();
        }

        public void IncreaseVolumeOneStep()
        {
            ChangeVolume(5, true);
        }

        public void DecreaseVolumeOneStep()
        {
            ChangeVolume(5, false);
        }

        private void ChangeVolume(int step, bool isIncreasing = true)
        {
            var currentVolume = int.Parse(_textComponent.text);
            // max and min values
            if ((isIncreasing && currentVolume >= 99) || 
                (!isIncreasing && currentVolume <= 0))
            {
                return;
            }
            currentVolume = currentVolume == 99 ? 100 : currentVolume; 
            
            var newVolume = isIncreasing ? 
                Mathf.Min(currentVolume + step, 100) : 
                Mathf.Max(currentVolume - step, 0);

            SetVolume(newVolume);
        }

        private void SetVolume(int volumeLevel)
        {
            AudioMixerController.Instance.SetVolumeMusic(volumeLevel, mixerTag);
            UpdateTextComponent(volumeLevel);
        }

        private void SyncTextComponentWithMixer()
        {
            var volumeLevel = AudioMixerController.Instance.GetVolumeMusic(mixerTag);
            UpdateTextComponent(volumeLevel);
        }

        private void UpdateTextComponent(int volumeLevel)
        {
            _textComponent.text = Mathf.Max(0, Mathf.Min(volumeLevel, 99)).ToString();
        }
    }
}