using System;
using SpaceMadness.Bistate;
using SpaceMadness.Structures;
using UnityEngine;

namespace SpaceMadness.Audio
{
    public abstract class BaseAudioManager<TEnum> : MonoBehaviour where TEnum : Enum
    {
        public NamedList<AudioItem, TEnum> audioItems;
        
        private void Awake()
        {
            var pairsIterator = audioItems.IterateThroughPairs();
            foreach (var keyWithAudio in pairsIterator)
            {
                var clip = keyWithAudio.Value.clip;
                
                var key = keyWithAudio.Key;
                
                // if null, ignore this sound effect
                if (clip == null)
                {
                    audioItems.SetByField(key, null);
                }
            }
        }

        /// <summary>
        /// Start to play sound effect related to the soundContext.
        /// It can stop the playback of an audio clip associated with the same AudioSource.
        /// </summary>
        /// <param name="soundContext">Context of the audio effect</param>
        /// <param name="playIfEqual">Whether to stop the playback of an audio clip
        /// associated with the same AudioSource if it's equal to the new one.</param>
        public void StartSound(TEnum soundContext, bool playIfEqual = false)
        {
            var audioItem = audioItems.GetByField(soundContext);

            if (audioItem == null)
            {
                return;
            }
            
            var clip = audioItem.clip;
            var source = audioItem.source;

            if (!playIfEqual && clip == source.clip && source.isPlaying)
            {
                return;
            }
            
            source.Stop();
            source.clip = clip;
            source.Play();
        }
    }
}