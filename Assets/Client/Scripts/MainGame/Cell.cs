using Assets.Client.Scripts.Helpers;
using UnityEngine;

namespace Assets.Client.Scripts.MainGame
{
    public class Cell
    {
        public ReactiveProperty<CellType> Type = new ReactiveProperty<CellType>();

        public Vector2Int Position { get => position; set => position = value; }
        private Vector2Int position;

        public Cell(Vector2Int position)
        {
            this.position = position;
            Type.Value = CellType.Empty;
        }

        public Cell(int i, int j) : this(new Vector2Int(i, j))
        {
        }
    }
}