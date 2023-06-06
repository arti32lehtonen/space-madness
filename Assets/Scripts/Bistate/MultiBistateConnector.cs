using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class MultiBistateConnector : 
        MonoBehaviour, IBistateStateApplier, IBistateTransitionProvider
    {
        [SerializeField] private List<BistateObject> relatedBistates;
        
        [Tooltip("When change state of the connected Bistates")]
        [SerializeField] private bool changeAfterTransition = true;
        
        [Tooltip("Use all Bistates with the tag as related bistates")]
        [SerializeField] private string collectBistatesWithTag;

        [Tooltip("If True, don't start apply after stage before all bistates finish transition")]
        [SerializeField] private bool synchronizeTransition = false;
        
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
                ChangeRelatedBistateStates();
            }
        }

        public void ApplyAfterTransition(bool newState)
        {
            if (changeAfterTransition)
            {
                ChangeRelatedBistateStates();
            }
        }

        private void ChangeRelatedBistateStates()
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

        public void StartTransition(bool newState)
        {
            // we don't start transition explicitly as
            // it starts in ApplyBeforeTransition or ApplyAfterTransition
        }

        public bool CheckIfDuringTransition()
        {
            if (!synchronizeTransition)
            {
                return false;
            }
            
            foreach (var bistate in relatedBistates)
            {
                if (!bistate.CheckIfAvailableToChange())
                {
                    return true;
                }
            }
            return false;
        }
    }
}