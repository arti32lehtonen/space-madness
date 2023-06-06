using System;
using UnityEngine;

namespace SpaceMadness.Audio
{
    [Serializable]
    public class AudioItem
    {
        public AudioClip clip;
        public AudioSource source;

        public override bool Equals(object obj)
        {
            return Equals(obj as AudioItem);
        }
        
        public bool Equals(AudioItem otherAudio)
        {
            return clip == otherAudio.clip && source == otherAudio.source;
        }
    }
}