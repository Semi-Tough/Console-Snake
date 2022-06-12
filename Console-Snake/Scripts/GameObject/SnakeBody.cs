using System;

namespace Console_Snake
{
    public enum ESnakeBodyType
    {
        Head,
        Body
    }

    public class SnakeBody : GameObject
    {
        private readonly ESnakeBodyType bodyType;

        public SnakeBody(ESnakeBodyType type,int x,int y)
        {
            bodyType = type;
            Position.X = x;
            Position.Y = y;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = bodyType == ESnakeBodyType.Head ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write(bodyType == ESnakeBodyType.Head ? "●" : "◎");
        }
    }
}