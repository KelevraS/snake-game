using Assets.Client.Scripts.MainGame;
using Assets.Client.Scripts.View.UI;
using UnityEngine;
using Grid = Assets.Client.Scripts.MainGame.Grid;

namespace Assets.Client.Scripts.View
{
    public class GameHandler : MonoBehaviour
    {
        private int rowCount, colCount;
        private float moveTimer, moveTimerMax;

        private Game game;
        private SpriteGameRenderer render;
        private GameSettingsReference gameSettings;
        private MainCanvas mainCanvas; 

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            FindAllReferences();

            InitGameSettings();
            CreateAndConfigureGame();
            CreateAndPrepareUI();
            
            render.CreateBoard(game.Grid.Cells);
        }

        private void FindAllReferences()
        {
            gameSettings = FindObjectOfType<GameSettingsReference>();
            render = FindObjectOfType<SpriteGameRenderer>();
            mainCanvas = FindObjectOfType<MainCanvas>();
        }

        private void CreateAndPrepareUI()
        {
            CreateScoreView();
            game.GameOver.OnValueChanged += CreateFinishView;
        }

        private void CreateScoreView()
        {
            mainCanvas.CreateScoreView(game.Snake.BodyLength);
        }

        private void CreateFinishView(bool isOver)
        {
            mainCanvas.CreateResultView(game.Snake.BodyLength);
        }

        private void InitGameSettings()
        {
            moveTimerMax = gameSettings.GameSettings.speed;
            rowCount = gameSettings.GameSettings.RowCount;
            colCount = gameSettings.GameSettings.ColCount;
        }

        private void CreateAndConfigureGame()
        {
            Grid grid = new Grid(rowCount, colCount);
            grid.CreateBorder();
            Snake snake = new Snake(new Cell(rowCount / 2, colCount / 2));
            grid.GenerateFood();
            game = new Game(grid, snake);

            SetupCam(grid);
        }

        private void SetupCam(Grid grid)
        {
            var cam = FindObjectOfType<CameraHandler>();
            cam.SetCameraPosition(grid);
        }

        private void Update()
        {
            moveTimer += Time.deltaTime;
            game.Direction = InputController.Instance.GetDirection();

            if (moveTimer < moveTimerMax)
                return;

            moveTimer -= moveTimerMax;
            game.Tick();
        }

        private void OnDestroy()
        {
            game.GameOver.OnValueChanged -= CreateFinishView;
        }
    }
}