using SpaceMadness.Structures;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceMadness.DamageSystem
{
    public class BarDisplay : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        
        public void UpdateBar(ICountableFinite damageable)
        {
            var fill = (float) damageable.GetCurrentValue() / damageable.GetMaxValue();
            fillImage.fillAmount = fill;
        }
    }
}