using Assets.Client.Scripts;
using Assets.Client.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.View.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private ResultView resultView;
        [SerializeField]
        private ScoreView scoreView;

        public void CreateResultView(ReactiveProperty<int> score)
        {
            Instantiate(resultView, transform).Init(score);
        }

        public void CreateScoreView(ReactiveProperty<int> score)
        {
            Instantiate(scoreView, transform).Init(score);

        }
    }
}