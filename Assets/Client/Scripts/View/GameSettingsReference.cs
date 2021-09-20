using Assets.Client.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.View
{
    public class GameSettingsReference : MonoBehaviour
    {
        [SerializeField]
        private GameSettings gameSettings;
        public GameSettings GameSettings => gameSettings;
    }
}