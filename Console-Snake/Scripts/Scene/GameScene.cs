using System;

namespace Console_Snake
{
    public class GameScene : ILifeCycle
    {
        private Map map;
        private Snake snake;
        private Food food;
        private int timer;

        public void Init()
        {
            map = new Map();
            map.Draw();
            snake = new Snake(40, 9);
            snake.Draw();
            food = new Food(snake);
        }

        public void Update()
        {
            if (timer % 15000 == 0)
            {
                snake.Move();
                snake.Draw();
                snake.CheckOver(map);
                snake.CheckFood(food);
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
    }
}