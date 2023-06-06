using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMadness.Bistate
{
    public class BistateObject : MonoBehaviour, IBistateObject
    {
        [SerializeField] private bool state;
        private IBistateTransitionProvider[] _bistateTransitions;
        private IBistateStateApplier[] _bistateAppliers;

        private float _stateUpdatePendingInterval = 0.05f;
        
        public void Awake()
        {
            _bistateTransitions = GetComponents<IBistateTransitionProvider>();            
            _bistateAppliers = gameObject.GetComponents<IBistateStateApplier>();
            SetState(state);
        }
        
        public bool GetState()
        {
            return state;
        }

        public void ChangeState()
        {
            if (!CheckIfAvailableToChange())
            {
                return;
            }
            
            SetState(!state);
        }

        public bool CheckIfAvailableToChange()
        {
            if (_bistateTransitions == null)
            {
                return true;
            }
            
            foreach (var transition in _bistateTransitions)
            {
                if (transition.CheckIfDuringTransition())
                {
                    return false;
                }
            }
            
            return true;
        }

        private void SetState(bool newState)
        {
            foreach (var applier in _bistateAppliers)
            {
                applier.ApplyBeforeTransition(newState);
            }

            foreach (var transition in _bistateTransitions)
            {
                transition?.StartTransition(newState);
            }
            
            StartCoroutine(DelayedStateUpdate(newState));
        }

        private IEnumerator DelayedStateUpdate(bool newState)
        {
            while (!CheckIfAvailableToChange())
            {
                yield return new WaitForSeconds(_stateUpdatePendingInterval);
            }
            
            foreach (var applier in _bistateAppliers)
            {
                applier.ApplyAfterTransition(newState);
            }
            state = newState;
        }
    }
}