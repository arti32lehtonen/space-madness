using System;
using UnityEngine;

namespace SpaceMadness
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime;
        [SerializeField] private float distanceThreshold;
        [SerializeField] private int pixelPerUnit;

        private Vector3 _velocity;

        public void LateUpdate()
        {
            Vector3 desiredPosition = target.position;
            desiredPosition.z = transform.position.z;

            float distance = Vector3.Distance(desiredPosition, transform.position);
            Vector3 smoothedPosition = Vector3.SmoothDamp(
                transform.position, desiredPosition, ref _velocity, smoothTime);

            Vector3 pixelRelatedPosition;
            if (pixelPerUnit != 0)
            {
                 pixelRelatedPosition= new Vector3(
                    Mathf.Round(desiredPosition.x * pixelPerUnit) / pixelPerUnit,
                    Mathf.Round(desiredPosition.y * pixelPerUnit) / pixelPerUnit,
                    desiredPosition.z
                );
            }
            else
            {
                pixelRelatedPosition = smoothedPosition;
            }

            transform.position = pixelRelatedPosition;
        }
    }
}