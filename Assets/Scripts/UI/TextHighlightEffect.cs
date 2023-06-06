using TMPro;
using UnityEngine;

namespace SpaceMadness.UI
{
    public class TextHighlightEffect : MonoBehaviour
    {
        [SerializeField] private Color highlightedColor;
        private Color _defaultColor;
        private TextMeshProUGUI _selfTextMeshPro;
        
        public void Awake()
        {
            _selfTextMeshPro = GetComponent<TextMeshProUGUI>();
            _defaultColor = _selfTextMeshPro.color;
        }

        public void StartHighlightText()
        {
            _selfTextMeshPro.color = highlightedColor;
        }

        public void StopHighlightText()
        {
            _selfTextMeshPro.color = _defaultColor;
        }
    }
}