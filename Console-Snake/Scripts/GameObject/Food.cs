using System;

namespace Console_Snake
{
    public class Food:GameObject
    {
        public Food(int x, int y)
        {
            Position = new Position(x, y);
        }
        
        public override void Draw()
        {
            Console.SetCursorPosition(Position.X,Position.Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("◆");
        }
    }
}