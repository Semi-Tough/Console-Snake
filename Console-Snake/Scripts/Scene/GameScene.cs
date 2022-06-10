using System;
using Console_Snake;

namespace Console_Snake
{
    public class GameScene:ILifeCycle
    {
        public void Init()
        {
            GameRoot.ChangeScene(ESceneType.End);
        }

        public void Update()
        {
        }
    }
}