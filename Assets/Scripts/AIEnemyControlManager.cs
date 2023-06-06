using System;
using SpaceMadness.DamageSystem;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

namespace SpaceMadness
{
    public class AIEnemyControlManager : MonoBehaviour
    {
        public Transform destinationTransform;
        
        private Vector2 _moveDirection;
        private bool _interactionStatus;
        private bool _shootingStatus;
            
        private Rigidbody2D _selfRigidBody;
        private IMovable _selfMovable;
        private IShooter _selfShooter;
        private NavMeshAgent _selfNavMeshAgent;

        public void Start()
        {
            _selfRigidBody = GetComponent<Rigidbody2D>();
            _selfMovable = GetComponent<IMovable>();
            _selfShooter = GetComponent<IShooter>();
            _selfNavMeshAgent = GetComponent<NavMeshAgent>();

            _selfNavMeshAgent.updateRotation = false;
            _selfNavMeshAgent.updateUpAxis = false;
            // Don’t update position automatically
            _selfNavMeshAgent.updatePosition = false;
            // Speed is set in separate class
            _selfNavMeshAgent.speed = _selfMovable.GetSpeed();
            _selfNavMeshAgent.SetDestination(destinationTransform.position);

            
        }
        
        public void FixedUpdate()
        {
            var direction = _selfNavMeshAgent.nextPosition - transform.position;
            _selfMovable.Move(direction);

        }
    }
}