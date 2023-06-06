using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class BulletProjectile : MonoBehaviour
    {
        [SerializeField] private int bulletDamage;
        [SerializeField] private GameObject explosionAnimation;
        private bool _isAlreadyExploded = false;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isAlreadyExploded)
            {
                _isAlreadyExploded = true;
                var contact = collision.GetContact(0);
                var explosionObject = Instantiate(
                    explosionAnimation, contact.point, Quaternion.identity);
                var damageable = collision.gameObject.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.GetDamage(bulletDamage);
                }
                
                Destroy(gameObject);
            }
        }
    }
}