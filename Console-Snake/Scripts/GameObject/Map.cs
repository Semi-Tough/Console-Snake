namespace Console_Snake
{
    public class Map : IDraw
    {
        public readonly Wall[] Walls;

        public Map()
        {
            Walls = new Wall[GameRoot.Wide + (GameRoot.High - 3) * 2];
            int index = 0;
            for (int i = 0; i < GameRoot.Wide; i += 2)
            {
                Walls[index++] = new Wall(i, 0);
                Walls[index++] = new Wall(i, GameRoot.High - 2);
            }

            for (int i = 1; i < GameRoot.High - 2; i++)
            {
                Walls[index++] = new Wall(0,i);
                Walls[index++] = new Wall(GameRoot.Wide-2,i);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < Walls.Length; i++)
            {
                Walls[i].Draw();
            }
        }
    }
}