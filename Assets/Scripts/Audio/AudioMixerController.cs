using SpaceMadness.Structures;
using UnityEngine;
using UnityEngine.Audio;

namespace SpaceMadness.Audio
{
    public class AudioMixerController : BaseSceneSingleton<AudioMixerController>
    {
        [SerializeField] private AudioMixer mixer;

        public void SetVolumeMusic(int volumeLevel, string mixerTag)
        {
            var scalableVolume = (float) volumeLevel / 100 + 0.001f;
            var mixerVolume = Mathf.Log10(scalableVolume) * 20;
            mixer.SetFloat(mixerTag, mixerVolume);
        }

        public int GetVolumeMusic(string mixerTag)
        {
            float mixerVolume;
            mixer.GetFloat(mixerTag, out mixerVolume);

            var scalableVolume = Mathf.Pow(10, mixerVolume / 20);
            var volumeLevel = Mathf.FloorToInt((scalableVolume - 0.001f) * 100);
            
            return volumeLevel;
        }
    }
}