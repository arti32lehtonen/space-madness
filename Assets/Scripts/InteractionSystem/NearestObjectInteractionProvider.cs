using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class NearestObjectInteractionProvider : MonoBehaviour, IInteractionProvider
    {
        [SerializeField] private float interactionRadius;
        [SerializeField] private string interactionLayerName;
        [SerializeField] private Transform playerTransform;
        private int _interactionLayerId;
        private GameObject _linkedObject;
        
        public void Awake()
        {
            _interactionLayerId = LayerMask.GetMask(interactionLayerName);
            
        }

        public InteractionState CheckInteractionState()
        {
            var nearestObject = Physics2D.OverlapCircle(
                playerTransform.position, interactionRadius, _interactionLayerId);
            
            bool isRelevantObject = InteractionUtils.CheckIfAllowedToInteract(nearestObject, gameObject);
            if (!isRelevantObject)
            {
                return InteractionState.None;
            }
            
            _linkedObject = nearestObject.gameObject;
            return InteractionState.Allow;
        }

        public GameObject GetLinkedObject()
        {
            return _linkedObject;
        }
    }
}