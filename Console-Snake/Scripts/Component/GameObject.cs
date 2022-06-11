namespace Console_Snake
{
    public abstract class GameObject : IDraw
    {
        public Position Position;
        public abstract void Draw();
    }
}