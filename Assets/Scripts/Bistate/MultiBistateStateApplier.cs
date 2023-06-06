using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class MultiBistateStateApplier : MonoBehaviour, IBistateStateApplier
    {
        [SerializeField] private List<BistateObject> relatedBistates;
        
        [Tooltip("When change state of the connected Bistates")]
        [SerializeField] private bool changeAfterTransition = true;
        
        [Tooltip("Use all Bistates with the tag as related bistates")]
        [SerializeField] private string collectBistatesWithTag;
        
        private bool _isInitialized = false;

        private void Awake()
        {
            if (!string.IsNullOrEmpty(collectBistatesWithTag))
            {
                var relatedBistatesByTag = 
                    BistateUtils.FindBistatesWithTag(collectBistatesWithTag);
                if (relatedBistates != null && relatedBistates.Count > 0)
                {
                    throw new ArgumentException(
                        "collectBistatesWithTag can't be used with non empty relatedBistates");
                }
                relatedBistates = relatedBistatesByTag;
            }
        }

        public void ApplyBeforeTransition(bool newState)
        {
            if (!changeAfterTransition)
            {
                ChangeStates();
            }
        }

        public void ApplyAfterTransition(bool newState)
        {
            if (changeAfterTransition)
            {
                ChangeStates();
            }
        }

        private void ChangeStates()
        {
            if (_isInitialized)
            {
                foreach (var bistate in relatedBistates)
                {
                    bistate.ChangeState();
                }
            }
            else
            {
                // initialize state and do nothing on init
                _isInitialized = true;
            }
        }
    }
}