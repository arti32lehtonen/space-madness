using System;
using System.Collections;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class DamageableAnimation : MonoBehaviour
    {
        [SerializeField] private float shiftSColor;
        [SerializeField] private float shiftHColor;

        private SpriteRenderer _render;
        private Color _baseColor;
        private bool _isDamagedNow = false;
        private IEnumerator _damageAnimation;

        private void Awake()
        {
            _render = GetComponent<SpriteRenderer>();
            _baseColor = _render.color;
        }

        private IEnumerator RunDamageAnimation()
        {
            Color.RGBToHSV(
                _render.color,
                out var hColor,
                out var sColor,
                out var vColor);
            float newSColor = sColor + shiftSColor;
            float newVColor = vColor + shiftHColor;
            var newRGBColor = Color.HSVToRGB(hColor, newSColor, newVColor);

            while (_isDamagedNow)
            {
                _isDamagedNow = false;
                
                _render.color = newRGBColor;
                yield return new WaitForSeconds(0.15f);
            
                _render.color = _baseColor;
                yield return new WaitForSeconds(0.15f);
            }

            _damageAnimation = null;
        }

        public void StartDamageAnimation()
        {
            _isDamagedNow = true;
            if (_damageAnimation == null)
            {
                _damageAnimation = RunDamageAnimation();
                StartCoroutine(_damageAnimation);
            }
            else
            {
                _isDamagedNow = true;
            }
        }

        public void StopDamageAnimation()
        {
            StopCoroutine(_damageAnimation);
            _render.color = _baseColor;
        }
        
    }
}