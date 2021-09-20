using Assets.Client.Scripts.Helpers;
using UnityEngine;

namespace Assets.Client.Scripts.MainGame
{
    public class Game
    {
        private ReactiveProperty<bool> gameOver = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> GameOver => gameOver;

        private Direction direction;
        public Direction Direction
        {
            get => direction;
            set
            {
                if (CheckNoneDirection(value))
                    return;

                if (CheckCounterDirection(direction, value) || CheckCounterDirection(value, direction))
                    return;

                direction = value;
            }
        }


        private bool CheckNoneDirection(Direction direction)
        {
            return direction == Direction.None;
        }

        private bool CheckCounterDirection(Direction dirA, Direction dirB)
        {
            var horizontalDir = dirA == Direction.Left && dirB == Direction.Right;
            var verticalDir = dirA == Direction.Up && dirB == Direction.Down;

            return horizontalDir || verticalDir;
        }

        private Grid grid;
        public Grid Grid => grid;
        private Snake snake;
        public Snake Snake => snake;

        public Game(Grid grid, Snake snake)
        {
            this.grid = grid;
            this.snake = snake;
        }

        public void Tick()
        {
            if (!gameOver.Value)
            {
                if (direction != Direction.None)
                {
                    Cell nextCell = GetNextCell(snake.Head);

                    if (snake.CheckCrash(nextCell))
                    {
                        direction = Direction.None;
                        gameOver.Value = true;
                    }
                    else
                    {
                        if (nextCell.Type.Value == CellType.Food)
                        {
                            snake.Grow(nextCell);
                            grid.GenerateFood();
                        }
                        else
                        {
                            snake.Move(nextCell);
                        }
                    }
                }
            }
        }

        private Cell GetNextCell(Cell currentCell)
        {
            Vector2Int currentPosition = currentCell.Position;

            switch (direction)
            {
                case Direction.Up:
                    currentPosition.y++;
                    break;

                case Direction.Down:
                    currentPosition.y--;
                    break;

                case Direction.Left:
                    currentPosition.x++;
                    break;

                case Direction.Right:
                    currentPosition.x--;
                    break;
            }

            Cell nextCell = grid.Cells[currentPosition.x, currentPosition.y];

            return nextCell;
        }
    }
}