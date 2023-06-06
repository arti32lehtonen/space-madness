using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceMadness.UI
{
    public class TextHighlightSelectTrigger : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        private TextHighlightEffect _textHighlight;

        public void Awake()
        {
            _textHighlight = transform.GetComponentInChildren<TextHighlightEffect>();
        }

        public void OnSelect(BaseEventData eventData)
        {
            _textHighlight.StartHighlightText();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _textHighlight.StopHighlightText();
        }
    }
}