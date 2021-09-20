using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Client.Scripts.Helpers
{
    public static class SceneManagementLayer
    {
        private const string GameSceneKey = "Game";
        public static void ReloadGameScene()
        {
            SceneManager.LoadScene(GameSceneKey);
        }
    }
}