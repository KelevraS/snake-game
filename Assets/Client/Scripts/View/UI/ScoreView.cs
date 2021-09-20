using Assets.Client.Scripts;
using Assets.Client.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Client.Scripts.View.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private Text score;

        private ReactiveProperty<int> scoreProperty;

        public void Init(ReactiveProperty<int> scoreProperty)
        {
            this.scoreProperty = scoreProperty;
            this.scoreProperty.OnValueChanged += UpdateScore;
            UpdateScore(0);
        }

        private void UpdateScore(int score)
        {
            this.score.text = $"Score: {score}";
        }

        private void OnDestroy()
        {
            scoreProperty.OnValueChanged -= UpdateScore;
        }
    }
}