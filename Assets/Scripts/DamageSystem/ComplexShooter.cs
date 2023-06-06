using System;
using UnityEngine;

namespace SpaceMadness.DamageSystem
{
    public class ComplexShooter: MonoBehaviour, IShooter
    {
        /// <summary>
        /// If true, then shooting action should be called inside on of the aspect
        /// Otherwise, it is called after all pre-shoot routines
        /// </summary>
        [SerializeField] private bool isShotTriggeredByEvent = false;

        private IShootingAspect[] _aspects;
        private IShootingAction _shootingAction;

        public void Awake()
        {
            _aspects = GetComponents<IShootingAspect>();
            _shootingAction = GetComponent<IShootingAction>();
        }

        public void RequestShooting()
        {
            foreach (var aspect in _aspects)
            {
                if (!aspect.CheckIfAllowedToShoot())
                {
                    ForbidAction();
                    return;
                }
            }

            foreach (var aspect in _aspects)
            {
                aspect.ExecutePreShootRoutine();
            }

            if (!isShotTriggeredByEvent)
            {
                ExecuteShootingAction();
            }

            foreach (var aspect in _aspects)
            {
                aspect.ExecutePostShootRoutine();
            }
        }
        
        private void ForbidAction()
        {
        }

        public void ExecuteShootingAction()
        {
            _shootingAction.Shoot();
        }
        
    }
}