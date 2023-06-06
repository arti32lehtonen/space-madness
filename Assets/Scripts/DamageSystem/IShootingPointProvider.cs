using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public interface IShootingPointProvider
    {
        public Vector3 GetShootingPoint(Vector3 viewDirection);
    }
}