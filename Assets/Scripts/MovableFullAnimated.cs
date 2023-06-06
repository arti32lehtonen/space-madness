using System;
using UnityEngine;

namespace SpaceMadness
{
    public class MovableFullAnimated : MonoBehaviour, IMovable
    {
        private float _movementSpeed;
        [SerializeField] private float _defaultSpeed;

        private Animator _selfAnimator;
        private Rigidbody2D _selfRigidBody;
        
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int HorizontalHash = Animator.StringToHash("Horizontal");
        private static readonly int LastHorizontalHash = 
            Animator.StringToHash("LastHorizontal");
        private static readonly int LastVerticalHash = 
            Animator.StringToHash("LastVertical");
        private static readonly int VerticalHash = Animator.StringToHash("Vertical");
        private static readonly int MouseHorizontalHash = 
            Animator.StringToHash("MouseHorizontal");
        private static readonly int MouseVerticalHash = 
            Animator.StringToHash("MouseVertical");
        private static readonly int MousePositionShiftHash = 
            Animator.StringToHash("MousePositionShift");

        private const float Eps = 1e-3f;

        public void Start()
        {
            _selfAnimator = GetComponent<Animator>();
            _selfRigidBody = GetComponent<Rigidbody2D>();

            _movementSpeed = _defaultSpeed;
        }

        public void Move(Vector2 direction)
        {
            Vector2 newVelocity = direction * _movementSpeed;
           _selfRigidBody.velocity = newVelocity;
           SetAnimatorParameters(direction);
        }

        private void SetAnimatorParameters(Vector2 direction)
        {
            _selfAnimator.SetFloat(SpeedHash, direction.sqrMagnitude);
            _selfAnimator.SetFloat(HorizontalHash, direction.x);
            _selfAnimator.SetFloat(VerticalHash, direction.y);
            
            if (direction.magnitude > Eps)
            {
                _selfAnimator.SetFloat(LastHorizontalHash, direction.x);
                _selfAnimator.SetFloat(LastVerticalHash, direction.y);
            }
        }

        public void ChangeSpeed(float multiplier, bool useDefault = true)
        {
            if (useDefault)
            {
                _movementSpeed = multiplier * _defaultSpeed;
            }
            else
            {
                _movementSpeed = multiplier * _movementSpeed;
            }
        }

        public float GetSpeed(bool useDefault = true)
        {
            return useDefault ? _defaultSpeed : _movementSpeed;
        }
    }
}