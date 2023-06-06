using Cinemachine;
using SpaceMadness.DamageSystem;
using UnityEngine;
using SpaceMadness.Structures;


namespace SpaceMadness
{
    public class SceneMainVariables : BaseSceneSingleton<SceneMainVariables>
    {
        [Header("Scene Variables")]
        public GameObject player;
        public Canvas hintsCanvas;
        public BarDisplay healthDisplay;
        public BarDisplay supplyDisplay;
        public CinemachineVirtualCamera virtualCamera;
        
        public void ReplacePlayer(GameObject newPlayer)
        {
            player.SetActive(false);

            var damageable = newPlayer.GetComponent<IDamageable>();

            var healthBar = healthDisplay;
            if (healthBar != null)
            {
                healthBar.UpdateBar(damageable);
                healthBar.gameObject.SetActive(true);
            }

            var supplyBar = supplyDisplay;
            if (supplyBar != null)
            {
                supplyBar.UpdateBar(damageable);
                supplyBar.gameObject.SetActive(true);
            }

            newPlayer.transform.position = player.transform.position;

            virtualCamera.Follow = newPlayer.transform;
            virtualCamera.LookAt = newPlayer.transform;
            
            var playerControls = newPlayer.GetComponent<PlayerControlManager>();
            playerControls.enabled = player.GetComponent<PlayerControlManager>().enabled;

            player = newPlayer;
            player.SetActive(true);
        }

    }
}