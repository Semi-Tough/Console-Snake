using System;

namespace Console_Snake
{
    public abstract class BaseScene : ILifeCycle
    {
        protected string Title;
        protected string FirstOption;
        protected string SecondOption;

        protected int CurrentIndex;

        public virtual void Init()
        {
            CurrentIndex = 0;
            SetTitleText();
            SetOptionsText();
        }

        public virtual void Update()
        {
            ChangeOption();
        }

        protected abstract void EnterOption();

        private void SetTitleText()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(GameRoot.Wide / 2 - Title.Length, 5);
            Console.Write(Title);
        }

        private void SetOptionsText()
        {
            Console.ForegroundColor = CurrentIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(GameRoot.Wide / 2 - FirstOption.Length, 8);
            Console.Write(FirstOption);

            Console.ForegroundColor = CurrentIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(GameRoot.Wide / 2 - SecondOption.Length, 10);
            Console.Write(SecondOption);
        }

        private void ChangeOption()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                {
                    CurrentIndex -= 1;
                    if (CurrentIndex < 0)
                    {
                        CurrentIndex = 0;
                    }

                    SetOptionsText();
                }
                    break;
                case ConsoleKey.S:
                {
                    CurrentIndex += 1;
                    if (CurrentIndex > 1)
                    {
                        CurrentIndex = 1;
                    }

                    SetOptionsText();
                }
                    break;
                case ConsoleKey.Enter:
                    EnterOption();
                    break;
            }
        }
    }
}