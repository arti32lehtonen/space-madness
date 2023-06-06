using System;
using TMPro;
using UnityEngine;

namespace SpaceMadness.UI
{
    public class TextFadingOnEnable : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;
        [SerializeField] private float fadeTime;
        private float deltaTime = 0.02f;
        
        private void Awake()
        {
            if (_textComponent == null)
            {
                _textComponent = GetComponent<TextMeshProUGUI>();
            }
        }

        private void OnEnable()
        {
            var fadedInCoroutine = TextFadingEffectUtils.ApplyTextFadeIn(
                fadeTime, deltaTime, _textComponent);
            StartCoroutine(fadedInCoroutine);
        }
    }
}