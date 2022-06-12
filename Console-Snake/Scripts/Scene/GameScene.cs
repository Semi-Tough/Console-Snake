using System;

namespace Console_Snake
{
    public class GameScene : ILifeCycle
    {
        private Map map;
        private Snake snake;
        private int timer;

        public void Init()
        {
            map = new Map();
            map.Draw();
            snake = new Snake(40, 9);
            snake.Draw();
        }

        public void Update()
        {
            if (timer % 30000 == 0)
            {
                snake.Move();
                snake.Draw();
                CheckOver();
                timer = 0;
            }

            timer++;
            CheckInput();
        }

        private void CheckInput()
        {
            if (!Console.KeyAvailable) return;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    snake.ChangeDir(EMoveDirType.Up);
                    break;
                case ConsoleKey.A:
                    snake.ChangeDir(EMoveDirType.Left);
                    break;
                case ConsoleKey.S:
                    snake.ChangeDir(EMoveDirType.Down);
                    break;
                case ConsoleKey.D:
                    snake.ChangeDir(EMoveDirType.Right);
                    break;
            }
        }

        private void CheckOver()
        {
            for (int i = 0; i < map.Walls.Length; i++)
            {
                if (map.Walls[i].Position == snake.SnakeBodies[0].Position)
                {
                    GameRoot.ChangeScene(ESceneType.End);
                }
            }

            for (int i = 1; i < snake.SnakeBodies.Count; i++)
            {
                if (snake.SnakeBodies[0].Position == snake.SnakeBodies[i].Position)
                {
                    GameRoot.ChangeScene(ESceneType.End);
                }
            }
        }
    }
}