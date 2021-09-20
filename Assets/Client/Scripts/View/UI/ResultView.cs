using Assets.Client.Scripts;
using Assets.Client.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Client.Scripts.View.UI
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField]
        private Text score;

        [SerializeField]
        private Button restart;

        public void Init(ReactiveProperty<int> result)
        {
            score.text = $"Score: {result.Value}";
        }

        private void Awake()
        {
            restart.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            SceneManagementLayer.ReloadGameScene();
        }

        private void OnDestroy()
        {
            restart.onClick.RemoveListener(RestartGame);
        }
    }
}