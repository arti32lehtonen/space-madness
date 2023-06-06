using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class RayCast2DInteractionProvider : MonoBehaviour, IInteractionProvider
    {
        public Transform playerTransform;
        public float maxDistance;
        private GameObject _linkedObject;

        private const float RayLength = 0.1f;

        public InteractionState CheckInteractionState()
        {
            var hit = RayCastUtils.GetHitFromRayCast(playerTransform.position, RayLength);
            bool isRelevantObject = InteractionUtils.CheckIfAllowedToInteract(hit.collider, gameObject);
            
            if (isRelevantObject)
            {
                _linkedObject = hit.transform.gameObject;
                var distance = Vector2.Distance(
                    _linkedObject.transform.position, playerTransform.position);
                var interactionState = distance < maxDistance ? 
                    InteractionState.Allow : InteractionState.Forbid;
                return interactionState;
            }

            return InteractionState.None;
        }

        public GameObject GetLinkedObject()
        {
            return _linkedObject;
        }
    }
}