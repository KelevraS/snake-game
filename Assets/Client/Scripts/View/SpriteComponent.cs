using Assets.Client.Scripts.MainGame;
using System;
using UnityEngine;

namespace Assets.Client.Scripts.View
{
    public class SpriteComponent : MonoBehaviour
    {
        private Cell cell;
        public Cell Cell => cell;

        private SpriteRenderer spriteRenderer;

        private Sprite sprite;

        private void Awake()
        {
            sprite = CreateSprite();

            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

        private void Start()
        {
            cell.Type.OnValueChanged += Type_OnValueChanged;
            Type_OnValueChanged(cell.Type.Value);
        }

        private void Type_OnValueChanged(CellType type)
        {
            switch (type)
            {
                case CellType.Empty:
                    spriteRenderer.color = Color.gray;
                    break;

                case CellType.Snake:
                    spriteRenderer.color = Color.green;
                    break;

                case CellType.Food:
                    spriteRenderer.color = Color.red;
                    break;

                case CellType.Border:
                    spriteRenderer.color = Color.black;
                    break;
            }    
        }

        private Sprite CreateSprite()
        {
            var tex = new Texture2D(100, 100);
            var rect = new Rect(0, 0, 100, 100);
            var pivot = Vector2.one / 2;
            return Sprite.Create(tex, rect, pivot);
        }

        public void Init(Cell cell)
        {
            this.cell = cell;

            transform.position = new Vector3(cell.Position.x, cell.Position.y);
        }
    }
}