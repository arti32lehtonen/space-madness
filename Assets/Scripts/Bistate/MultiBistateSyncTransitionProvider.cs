using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.Bistate
{
    /// <summary>
    /// This class is recommended to use only with MultiBistateStateApplier.
    /// It synchronizes transition of all connected bistates.
    /// </summary>
    public class MultiBistateSyncTransitionProvider : MonoBehaviour, IBistateTransitionProvider
    {
        [SerializeField] private List<BistateObject> relatedBistates;
        private List<IBistateTransitionProvider> relatedBistateTransitions;

        private bool _isInitialized = false;
        
        public void Awake()
        {
            relatedBistateTransitions = new List<IBistateTransitionProvider>();
            foreach (var bistate in relatedBistates)
            {
                relatedBistateTransitions.Add(
                    bistate.GetComponent<IBistateTransitionProvider>());
            }
            relatedBistates.Clear();
            _isInitialized = true;
        }

        public void StartTransition(bool newState)
        {
            // we don't start transition explicitly as
            // it starts in MultiBistateStateApplier
        }

        public bool CheckIfDuringTransition()
        {
            if (!_isInitialized)
            {
                return true;
            }
            
            foreach (var transition in relatedBistateTransitions)
            {
                if (transition.CheckIfDuringTransition())
                {
                    return true;
                }
            }
            return false;
        }
    }
}