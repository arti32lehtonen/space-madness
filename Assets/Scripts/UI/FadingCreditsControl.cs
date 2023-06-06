using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceMadness.UI
{
    [Serializable]
    public class CreditItem
    {
        [SerializeField] private string title;
        [SerializeField] [TextArea(1, 3)] private string names;
        [SerializeField] [TextArea(1, 5)] private string links;

        private const string StringToFormat =
            "<smallcaps><size=80%><b>{0}</b></size=80%>\n\n{1}</smallcaps>" +
            "\n\n<size=80%>{2}</size=80%>";

        public void FillTextComponent(TextMeshProUGUI textComponent)
        {
            string textString = string.Format(StringToFormat, title, names, links);
            textComponent.text = textString;
        }
    } 
    
    public class FadingCreditsControl : MonoBehaviour
    {
        [SerializeField] private float fadeTime;
        [SerializeField] private float deltaTime;
        [SerializeField] private TextMeshProUGUI textComponent;

        [SerializeField] private List<CreditItem> creditTexts;

        private IEnumerator _creditCoroutine;

        private void OnEnable()
        {
            _creditCoroutine = RunCredits();
            StartCoroutine(_creditCoroutine);
        }

        private IEnumerator RunCredits()
        {
            foreach (var creditItem in creditTexts)
            {
                creditItem.FillTextComponent(textComponent);
                var startCoroutine = TextFadingEffectUtils.ApplyTextFadeIn(
                    fadeTime, deltaTime, textComponent);
                yield return startCoroutine;
                
                yield return new WaitForSeconds(1f);

                var endCoroutine = TextFadingEffectUtils.ApplyTextFadeOut(
                    fadeTime, deltaTime, textComponent);
                yield return endCoroutine;
            }

            yield return new WaitForSeconds(1.0f);
            gameObject.SetActive(false);
        }
    }
}