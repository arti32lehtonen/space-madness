using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMadness
{
    public class NewSceneStarter : MonoBehaviour
    {
        [SerializeField] private float baseDelay;
        
        public static void StartNewScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void DelayedStartNewScene(string sceneName, float delay)
        {
            StartCoroutine(DelayedSceneStart(sceneName, delay));
        }

        private static IEnumerator DelayedSceneStart(string sceneName, float delay)
        {
            yield return new WaitForSeconds(delay);
            StartNewScene(sceneName);
        } 

        public void DelayedStartNewScene(string sceneName)
        {
            DelayedStartNewScene(sceneName, baseDelay);
        }
        
    }
}