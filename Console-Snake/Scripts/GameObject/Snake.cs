using System;
using System.Collections.Generic;

namespace Console_Snake
{
    public enum EMoveDirType
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Snake : IDraw
    {
        public List<SnakeBody> SnakeBodies;
        private EMoveDirType moveDirType;

        public Snake(int x, int y)
        {
            SnakeBodies = new List<SnakeBody>(15)
            {
                new SnakeBody(ESnakeBodyType.Head, x, y)
            };
            moveDirType = EMoveDirType.Right;
        }

        public void Draw()
        {
            for (int i = 0; i < SnakeBodies.Count; i++)
            {
                SnakeBodies[i].Draw();
            }
        }

        public void Move()
        {
            Console.SetCursorPosition(SnakeBodies[0].Position.X, SnakeBodies[0].Position.Y);
            Console.Write("  ");

            switch (moveDirType)
            {
                case EMoveDirType.Up:
                    SnakeBodies[0].Position.Y--;
                    break;
                case EMoveDirType.Down:
                    SnakeBodies[0].Position.Y++;
                    break;
                case EMoveDirType.Left:
                    SnakeBodies[0].Position.X -= 2;
                    break;
                case EMoveDirType.Right:
                    SnakeBodies[0].Position.X += 2;
                    break;
            }
        }

        public void ChangeDir(EMoveDirType dirType)
        {
            if (moveDirType == dirType) return;
            if (SnakeBodies.Count > 1)
            {
                switch (moveDirType)
                {
                    case EMoveDirType.Left when dirType == EMoveDirType.Right:
                    case EMoveDirType.Right when dirType == EMoveDirType.Left:
                    case EMoveDirType.Down when dirType == EMoveDirType.Up:
                    case EMoveDirType.Up when dirType == EMoveDirType.Down:
                        return;
                }
            }

            moveDirType = dirType;
        }
    }
}