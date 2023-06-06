using System.Collections;
using UnityEngine;

namespace SpaceMadness.Audio
{
    public static class FadingEffectUtils
    {
        public static IEnumerator ApplyFadingIn(
            AudioSource source, float fadeTime, 
            float targetVolume = 1, bool fromInitialVolume = false)
        {
            if (!fromInitialVolume)
            {
                source.volume = 0f;
            }
            
            source.Play();
            
            while (source.volume < targetVolume)
            {
                source.volume += Time.deltaTime / fadeTime;
                yield return null;
            }

            source.volume = targetVolume;
        }
        
        public static IEnumerator ApplyFadingOut(
            AudioSource source, float fadeTime,
            float targetVolume = 0, bool fromInitialVolume = false)
        {
            if (!fromInitialVolume)
            {
                source.volume = 1f;
            }

            while (source.volume > targetVolume)
            {
                source.volume -= Time.deltaTime / fadeTime;
                yield return null;
            }
            
        }


    }
}