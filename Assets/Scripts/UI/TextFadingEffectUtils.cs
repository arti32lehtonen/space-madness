using System.Collections;
using TMPro;
using UnityEngine;

namespace SpaceMadness.UI
{
    public static class TextFadingEffectUtils
    {
        public static IEnumerator ApplyTextFadeIn(
            float fadeTime, float deltaTime, TextMeshProUGUI textComponent)
        {
            yield return ApplyTextFade(fadeTime, deltaTime, textComponent, true);
        }

        public static IEnumerator ApplyTextFadeOut(
            float fadeTime, float deltaTime, TextMeshProUGUI textComponent)
        {

            yield return ApplyTextFade(fadeTime, deltaTime, textComponent, false);
        }

        private static IEnumerator ApplyTextFade(
            float fadeTime, float deltaTime, TextMeshProUGUI textComponent, bool fadeIn)
        {
            var nUpdates = Mathf.RoundToInt(fadeTime / deltaTime);

            for (int i = 0; i <= nUpdates; i++)
            {
                var alphaValue = (float) i / nUpdates;
                if (!fadeIn)
                {
                    alphaValue = 1 - alphaValue;
                }
                
                textComponent.color = new Color(
                    textComponent.color.r,
                    textComponent.color.g,
                    textComponent.color.b,
                    alphaValue);
                yield return new WaitForSeconds(deltaTime);
            }
        }
        
    }
}