using UnityEngine;

namespace SpaceMadness
{
    public class NewSceneOnStageStarter : MonoBehaviour
    {
        [SerializeField] private Stage stage;
        [SerializeField] private string sceneName;

        private void Awake()
        {
            if (stage == Stage.Awake)
            {
                NewSceneStarter.StartNewScene(sceneName);
            }
        }

        private void Start()
        {
            if (stage == Stage.Start)
            {
                NewSceneStarter.StartNewScene(sceneName);
            }
        }

        private void OnEnable()
        {
            if (stage == Stage.OnEnable)
            {
                NewSceneStarter.StartNewScene(sceneName);
            }
        }

        private void OnDisable()
        {
            if (stage == Stage.OnDisable)
            {
                NewSceneStarter.StartNewScene(sceneName);
            }
        }
    }
}