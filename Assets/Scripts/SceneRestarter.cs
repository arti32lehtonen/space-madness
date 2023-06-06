using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMadness
{
    public class SceneRestarter : MonoBehaviour
    {
        public static void RestartScene()
        {
            var activeScene = SceneManager.GetActiveScene();
            NewSceneStarter.StartNewScene(activeScene.name);
        }
    }
}