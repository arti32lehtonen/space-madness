using SpaceMadness.Structures;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceMadness.DamageSystem
{
    public class MainDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private CountableFinite hitPoints;
        [SerializeField] private BarDisplay _linkedHealthBar;
        [SerializeField] private bool destroyOnDeath;

        private IOnDeathActivator[] _onDeathActivators;
        private DamageableAnimation _damageableAnimation;

        public void Awake()
        {
            if (_linkedHealthBar != null)
            {
                _linkedHealthBar.UpdateBar(hitPoints);
            }

            _onDeathActivators = GetComponents<IOnDeathActivator>();
            _damageableAnimation = GetComponent<DamageableAnimation>();
        }

        public bool GetDamage(int damageAmount)
        {
            hitPoints.ChangeCurrentValue(-damageAmount);
            
            if (_linkedHealthBar != null)
            {
                _linkedHealthBar.UpdateBar(hitPoints);
            }

            if (_damageableAnimation != null && damageAmount > 0)
            {
                _damageableAnimation.StartDamageAnimation();
            }

            bool isDestroyed = CheckIfDestroyed();

            if (isDestroyed)
            {
                RunDestroyProcedure();
            }

            return isDestroyed;
        }

        private void RunDestroyProcedure()
        {
            if (_damageableAnimation != null)
            {
                _damageableAnimation.StopDamageAnimation();
            }
                
            foreach (var activator in _onDeathActivators)
            {
                activator.OnDeath();
            }

            if (destroyOnDeath)
            {
                Destroy(gameObject, 0.1f);
            }
        }
        
        public bool CheckIfDestroyed()
        {
            return hitPoints.GetCurrentValue() == 0;
        }

        public int GetCurrentValue()
        {
            return hitPoints.GetCurrentValue();
        }

        public int GetMaxValue()
        {
            return hitPoints.GetMaxValue();
        }

        public void ChangeCurrentValue(int changeModifier)
        {
            // don't need it as change happens inside GetDamage
            throw new System.NotImplementedException();
        }
    }
}