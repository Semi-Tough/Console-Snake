using System;
using System.Threading;

namespace Console_Snake
{
    public class GameScene : ILifeCycle
    {
        private Map map;
        private Snake snake;
        private Food food;
        private Thread thread;

        public void Init()
        {
            map = new Map();
            map.Draw();
            snake = new Snake(40, 9);
            snake.Draw();
            food = new Food(snake);
            thread = new Thread(CheckInput)
            {
                IsBackground = true
            };
            thread.Start();
        }

        public void Update()
        {
            Thread.Sleep(snake.MoveInterval);
            snake.Move();
            snake.Draw();
            snake.CheckOver(map);
            snake.CheckFood(food);
        }

        private void CheckInput()
        {
            while (true)
            {
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
                    case ConsoleKey.Spacebar:
                        snake.MoveInterval = snake.MoveInterval == 500 ? 200 : 500;
                        break;
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}