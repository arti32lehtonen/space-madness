using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceMadness
{
    public static class RayCastUtils
    {
        public static Vector3 GetMouseWorldCoordinates()
        {
            if (Camera.main == null)
            {
                throw new InvalidOperationException("Camera is not initialized");
            }
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            return mousePosition;
        }

        public static Vector3 GetDirectionToMouseCoordinates(
            Vector3 targetPosition, bool normalize = true)
        {
            var mouseCoordinates = GetMouseWorldCoordinates();
            mouseCoordinates.z = targetPosition.z;
            var viewDirection = mouseCoordinates - targetPosition;
            if (normalize)
            {
                viewDirection = viewDirection.normalized;
            }
            return viewDirection;
        }

        public static RaycastHit2D GetHitFromRayCast(
            Vector3 targetPosition, float rayLength = 0.1f)
        {
            var mousePosition = GetMouseWorldCoordinates();
            RaycastHit2D hit = Physics2D.Raycast(
                mousePosition, 
                mousePosition - targetPosition, rayLength);

            return hit;
        }

    }
}