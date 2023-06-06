using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class MouseBasedDirectionProvider : MonoBehaviour, IShootingDirectionProvider
    {
        public Vector3 GetShootingDirection()
        {
            var viewDirection = RayCastUtils.GetDirectionToMouseCoordinates(
                transform.position);
            return viewDirection;
        }
    }
}