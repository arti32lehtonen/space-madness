using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.InteractionSystem
{
    public class MaterialChangeInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        public Material highlightMaterial;
        private Dictionary<GameObject, Material> _objectToMaterial = new();
        
        public void OnAllowInteraction(GameObject linkedObject)
        {
            // already responded 
            if (_objectToMaterial.ContainsKey(linkedObject))
            {
                return;
            }
            var sprite = linkedObject.GetComponent<SpriteRenderer>();
            _objectToMaterial[linkedObject] = sprite.material;
            sprite.material = highlightMaterial;
        }

        public void OnForbidInteraction(GameObject linkedObject)
        {
            StopHighlight(linkedObject);
        }

        public void OnStopInteraction(GameObject linkedObject)
        {
            StopHighlight(linkedObject);
        }

        private void StopHighlight(GameObject linkedObject)
        {
            if (_objectToMaterial.ContainsKey(linkedObject))
            {
                var sprite = linkedObject.GetComponent<SpriteRenderer>();
                sprite.material = _objectToMaterial[linkedObject];
                _objectToMaterial.Remove(linkedObject);
            }
        }
    }
}