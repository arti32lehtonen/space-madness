using System;
using System.Collections;
using SpaceMadness.Structures;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


namespace SpaceMadness.UI
{
    public class SelectManager : BaseSceneSingleton<SelectManager>
    {
        private GameObject _selectedButtonObject;
        private PlayerControlsActions _actions;
        private AudioSource _selfSource;
        private const float SecondsBetweenActions = 0.5f;

        protected override void OnAwake()
        {
            _selfSource = GetComponent<AudioSource>();
        }

        public void OnEnable()
        {
            _actions = new PlayerControlsActions();
            _actions.Enable();
            GetClickAction().performed += OnClick;
        }

        public void OnDisable()
        {
            GetClickAction().performed -= OnClick;
            _actions.Disable();
        }

        private void OnClick(InputAction.CallbackContext callbackContext)
        {
            var selectedButtonObject = EventSystem.current.currentSelectedGameObject;
            
            if (selectedButtonObject != null && selectedButtonObject.activeInHierarchy)
            {
                var button = selectedButtonObject.GetComponent<Button>();
                button.onClick.Invoke();

                if (_selfSource != null)
                {
                    _selfSource.Play();
                }
            }
        }
        
        private InputAction GetClickAction()
        {
            return _actions.UI.Click;
        }

        public void SelectGameObject(GameObject objectToSelect)
        {
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(null);
            eventSystem.SetSelectedGameObject(objectToSelect, new BaseEventData(eventSystem));
        }
    }
}