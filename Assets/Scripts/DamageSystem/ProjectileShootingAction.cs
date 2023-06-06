using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceMadness.DamageSystem
{
    public class ProjectileShootingAction : MonoBehaviour, IShootingAction
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private List<Collider2D> ignoredColliders; 
        
        private IShootingDirectionProvider _directionProvider;
        private IShootingPointProvider _pointProvider;
        
        public void Awake()
        {
            _directionProvider = GetComponent<IShootingDirectionProvider>();
            _pointProvider = GetComponent<IShootingPointProvider>();
        }
        
        public void Shoot()
        {
            var viewDirection = _directionProvider.GetShootingDirection();
            var bulletOrientation = Mathf.Atan2(viewDirection.y, viewDirection.x) * Mathf.Rad2Deg;
            var bulletPosition = _pointProvider.GetShootingPoint(viewDirection);
            
            var projectile = InstantiateProjectile(bulletPosition, bulletOrientation);
            var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidBody.velocity = viewDirection * projectileSpeed;
        }

        private GameObject InstantiateProjectile(Vector3 bulletPosition, float bulletOrientation)
        {
            GameObject bullet = Instantiate(
                projectilePrefab, bulletPosition, Quaternion.identity);
            bullet.transform.Rotate(0, 0, bulletOrientation);

            // forbid to collide with the colliders of the shooter
            var bulletCollider = bullet.GetComponent<Collider2D>();
            foreach (var attachedCollider in ignoredColliders)
            {
                Physics2D.IgnoreCollision(bulletCollider, attachedCollider);
            }

            return bullet;
        }

    }
}