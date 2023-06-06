using System;
using UnityEngine;

namespace SpaceMadness
{
    public class PlayerControlLock : MonoBehaviour
    {
        public void OnEnable()
        {
            if (SceneMainVariables.Instance == null)
            {
                return;
            }
            var playerObject = SceneMainVariables.Instance.player;
            if (playerObject != null)
            {
                var controlComponent = playerObject.GetComponent<PlayerControlManager>();
                controlComponent.enabled = false;
            }
        }

        public void OnDisable()
        {
            if (SceneMainVariables.Instance == null)
            {
                return;
            }
            var playerObject = SceneMainVariables.Instance.player;
            if (playerObject != null)
            {
                var controlComponent = playerObject.GetComponent<PlayerControlManager>();
                controlComponent.enabled = true;
            }
        }
    }
}