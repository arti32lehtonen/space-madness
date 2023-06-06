using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public interface IShootingDirectionProvider
    {
        public Vector3 GetShootingDirection();
    }
}