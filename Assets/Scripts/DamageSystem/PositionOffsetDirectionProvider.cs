using System;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class PositionOffsetDirectionProvider : MonoBehaviour, IShootingPointProvider
    {
        [SerializeField] private float bulletOffset;
        [SerializeField] private Transform firePoint;

        public void Awake()
        {
            if (firePoint == null)
            {
                firePoint = transform;
            }
        }

        public Vector3 GetShootingPoint(Vector3 viewDirection)
        {
            return firePoint.position + bulletOffset * viewDirection;
        }
    }
}