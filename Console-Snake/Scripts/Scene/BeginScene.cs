using System;

namespace Console_Snake
{
    public class BeginScene:BaseScene
    {
       
        public override void Init()
        {
            Title = "贪吃蛇";
            FirstOption = "开始游戏";
            SecondOption = "退出游戏";
            base.Init();
        }

        protected override void EnterOption()
        {
            if (CurrentIndex == 0)
            {
                GameRoot.ChangeScene(ESceneType.Game);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}