using System;
using Console_Snake;

namespace Console_Snake
{
    public class GameScene:ILifeCycle
    {
        public void Init()
        {
            Map map = new Map();
            map.Draw();
        }

        public void Update()
        {
        }
    }
}