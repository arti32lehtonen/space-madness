using System.Collections.Generic;
using SpaceMadness.Bistate;
using SpaceMadness.InteractionSystem;
using UnityEngine;

namespace SpaceMadness.Interactables
{
    public class BistateRemoteController : MonoBehaviour, IInteractable
    {
        public List<BistateObject> relatedBistates;
        
        public void Interact(GameObject interactorObject)
        {
            foreach (var bistateObject in relatedBistates)
            {
                bistateObject.ChangeState();
            }
        }

        public bool CheckIfAvailable(GameObject interactorObject)
        {
            foreach (var bistate in relatedBistates)
            {
                if (!bistate.CheckIfAvailableToChange())
                {
                    return false;
                }
            }

            return true;
        }
    }
}