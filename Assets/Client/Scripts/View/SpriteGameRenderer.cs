using Assets.Client.Scripts.MainGame;
using Assets.Client.Scripts.View;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.View
{
    public class SpriteGameRenderer : MonoBehaviour
    {
        private List<SpriteComponent> gameCells = new List<SpriteComponent>();

        public void CreateBoard(Cell[,] cells)
        {
            var gameSettings = FindObjectOfType<GameSettingsReference>();

            foreach (var cell in cells)
            {
                var spriteComponent = new GameObject().AddComponent<SpriteComponent>();
                spriteComponent.transform.SetParent(transform);
                spriteComponent.Init(cell);
                gameCells.Add(spriteComponent);
            }
        }
    }
}