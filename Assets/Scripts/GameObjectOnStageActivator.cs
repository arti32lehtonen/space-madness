using System;
using UnityEngine;

namespace SpaceMadness
{
    enum Stage
    {
        Awake,
        Start,
        OnEnable,
        OnDisable
    }
    
    
    public class GameObjectOnStageActivator : MonoBehaviour
    {
        [SerializeField] private Stage stage;
        [SerializeField] private GameObject linkedObject;
        [SerializeField] private bool needToActivate = true;

        private void Awake()
        {
            if (stage == Stage.Awake)
            {
                linkedObject.SetActive(needToActivate);
            }
        }

        private void Start()
        {
            if (stage == Stage.Start)
            {
                linkedObject.SetActive(needToActivate);
            }
        }

        private void OnEnable()
        {
            if (stage == Stage.OnEnable)
            {
                linkedObject.SetActive(needToActivate);
            }
        }

        private void OnDisable()
        {
            if (stage == Stage.OnDisable)
            {
                linkedObject.SetActive(needToActivate);
            }
        }
    }
}