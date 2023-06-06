using System;
using UnityEngine;

namespace SpaceMadness
{
    public class ChangePlayerOnEnable : MonoBehaviour
    {
        [SerializeField] private GameObject newPlayer;

        public void OnEnable()
        {
            SceneMainVariables.Instance.ReplacePlayer(newPlayer);
        }
    }
}