using System;
using SpaceMadness.DamageSystem;
using SpaceMadness.InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceMadness
{
    public class PlayerControlManager : MonoBehaviour
    {
        [SerializeField] private Canvas menuCanvas;
        
        PlayerControlsActions _actions;
        
        private Vector2 _moveDirection;
        private bool _interactionStatus;
        private bool _shootingStatus;
            
        private Rigidbody2D _selfRigidBody;
        private IMovable _selfMovable;
        private IInteractor _selfInteractor;
        private IShooter _selfShooter;
        
        public void Awake()
        {
            _selfRigidBody = GetComponent<Rigidbody2D>();
            _selfMovable = GetComponentInChildren<IMovable>();
            _selfInteractor = GetComponentInChildren<IInteractor>();
            _selfShooter = GetComponentInChildren<IShooter>();
        }

        public void OnEnable()
        {
            _actions = new PlayerControlsActions();
            _actions.Enable();

            if (_selfMovable != null)
            {
                _actions.Player.Movement.performed += SetMovementVector;
                _actions.Player.Movement.canceled += SetMovementVector;
            }

            if (_selfInteractor != null)
            {
                _actions.Player.Interaction.started += SetInteractionStatus;
                _actions.Player.Interaction.canceled += SetInteractionStatus;
            }

            if (_selfShooter != null)
            {
                _actions.Player.Shooting.performed += SetShootingStatus;
                _actions.Player.Shooting.canceled += SetShootingStatus;
            }

            _actions.Player.Menu.performed += ShowMenu;
            _actions.Player.Menu.canceled += ShowMenu;
        }

        public void OnDisable()
        {
            _actions.Player.Movement.performed -= SetMovementVector;
            _actions.Player.Movement.canceled -= SetMovementVector;
            
            _actions.Player.Interaction.started -= SetInteractionStatus;
            _actions.Player.Interaction.canceled -= SetInteractionStatus;
            
            _actions.Player.Shooting.performed -= SetShootingStatus;
            _actions.Player.Shooting.canceled -= SetShootingStatus;
            
            _actions.Player.Menu.performed -= ShowMenu;
            _actions.Player.Menu.canceled -= ShowMenu;
        
            _actions.Disable();

            FlushActions();
        }

        private void RequestActions()
        {
            _selfInteractor.RequestInteraction(_interactionStatus);
            _interactionStatus = false;

            if (_shootingStatus)
            {
                _selfShooter.RequestShooting();
                _shootingStatus = false;
            }
        }

        private void FlushActions()
        {
            if (_moveDirection != Vector2.zero)
            {
                _moveDirection = Vector2.zero;
                _selfMovable.Move(_moveDirection);
            }
            
            if (_interactionStatus)
            {
                _interactionStatus = false;
                _selfInteractor.RequestInteraction(_interactionStatus);
            }

            if (_shootingStatus)
            {
                _shootingStatus = false;
            }
        }
        
        void SetMovementVector(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }

        void SetInteractionStatus(InputAction.CallbackContext context)
        {
            if (!_interactionStatus)
            {
                _interactionStatus = context.started;
            }
        }

        void SetShootingStatus(InputAction.CallbackContext context)
        {
            _shootingStatus = context.performed;
        }

        void ShowMenu(InputAction.CallbackContext context)
        {
            menuCanvas.gameObject.SetActive(true);
        }

        public void FixedUpdate()
        {
            _selfMovable.Move(_moveDirection);
        }

        public void Update()
        {
            RequestActions();
        }
    }
}
