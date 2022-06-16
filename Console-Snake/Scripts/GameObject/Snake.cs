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
        public readonly List<SnakeBody> SnakeBodies;
        private EMoveDirType moveDirType;
        public int MoveInterval;

        public Snake(int x, int y)
        {
            SnakeBodies = new List<SnakeBody>(15)
            {
                new SnakeBody(ESnakeBodyType.Head, x, y)
            };
            moveDirType = EMoveDirType.Right;
            MoveInterval = 500;
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
            Console.SetCursorPosition(SnakeBodies[SnakeBodies.Count - 1].Position.X,
                SnakeBodies[SnakeBodies.Count - 1].Position.Y);
            Console.Write("  ");
            
            for (int i = SnakeBodies.Count - 1; i > 0; i--)
            {
                SnakeBodies[i].Position = SnakeBodies[i - 1].Position;
            }

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

        public void CheckFood(Food food)
        {
            if (SnakeBodies[0].Position == food.Position)
            {
                food.RandomPos(this);
                AddBody();
            }
        }

        private void AddBody()
        {
            SnakeBody lastBody = SnakeBodies[SnakeBodies.Count - 1];
            SnakeBodies.Add(new SnakeBody(ESnakeBodyType.Body, lastBody.Position.X, lastBody.Position.Y));
        }

        public void CheckOver(Map map)
        {
            for (int i = 0; i < map.Walls.Length; i++)
            {
                if (map.Walls[i].Position == SnakeBodies[0].Position)
                {
                    GameRoot.ChangeScene(ESceneType.End);
                }
            }

            for (int i = 1; i < SnakeBodies.Count; i++)
            {
                if (SnakeBodies[0].Position == SnakeBodies[i].Position)
                {
                    GameRoot.ChangeScene(ESceneType.End);
                }
            }
        }
    }
}