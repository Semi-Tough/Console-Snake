namespace Console_Snake
{
    public class Map : IDraw
    {
        private readonly Wall[] walls;

        public Map()
        {
            walls = new Wall[GameRoot.Wide + (GameRoot.High - 3) * 2];
            int index = 0;
            for (int i = 0; i < GameRoot.Wide; i += 2)
            {
                walls[index++] = new Wall(i, 0);
                walls[index++] = new Wall(i, GameRoot.High - 2);
            }

            for (int i = 1; i < GameRoot.High - 2; i++)
            {
                walls[index++] = new Wall(0,i);
                walls[index++] = new Wall(GameRoot.Wide-2,i);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }
    }
}