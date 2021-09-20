using UnityEngine;

namespace Assets.Client.Scripts.MainGame
{
    public class Grid
    {
        private int col;
        public int Col => col;
        private int row;
        public int Row => row;

        private Cell[,] cells;
        public Cell[,] Cells { get => cells; set => cells = value; }

        public Grid(int row, int col)
        {
            this.row = row;
            this.col = col;

            cells = new Cell[col, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }

        public void CreateBorder()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0 || i == row - 1 || j == 0 || j == col - 1)
                        cells[i, j].Type.Value = CellType.Border;
                }
            }
        }

        public void GenerateFood()
        {
            GetRandomCellExcludingType().Type.Value = CellType.Food;
        }

        private Cell GetCell(int row, int col)
        {
            return cells[row, col];
        }

        private Cell GetRandomCellExcludingType()
        {
            int row;
            int col;

            do
            {
                row = Random.Range(0, this.row);
                col = Random.Range(0, this.col);
            }
            while (GetCell(row, col).Type.Value == CellType.Snake || GetCell(row, col).Type.Value == CellType.Border);

            return cells[row, col];
        }
    }
}