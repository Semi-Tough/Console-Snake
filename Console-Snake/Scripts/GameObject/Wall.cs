using System;

namespace Console_Snake
{
    public class Wall:GameObject
    {
        public Wall(int x,int y)
        {
            Position = new Position(x, y);
        }
        
        public override void Draw()
        {
            Console.SetCursorPosition(Position.X,Position.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }
    }
}