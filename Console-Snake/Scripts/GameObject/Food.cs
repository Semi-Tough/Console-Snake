using System;

namespace Console_Snake
{
    public class Food : GameObject
    {
        public Food(Snake snake)
        {
            RandomPos(snake);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("◆");
        }

        public void RandomPos(Snake snake)
        {
            Random random = new Random();
            int x = random.Next(1, GameRoot.Wide / 2 - 1) * 2;
            int y = random.Next(1, GameRoot.High - 2);
            Position = new Position(x, y);
            if (!CheckPosition(snake, Position))
            {
                RandomPos(snake);
            }
            Draw();
        }

        private static bool CheckPosition(Snake snake, Position position)
        {
            for (int i = 0; i < snake.SnakeBodies.Count; i++)
            {
                if (snake.SnakeBodies[i].Position == position)
                {
                    return false;
                }
            }

            return true;
        }
    }
}