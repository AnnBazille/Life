using System.Collections.Generic;
using System.Threading;

namespace LifeLibrary
{
    public class TimeController<T> where T : class, IPrinter, new()
    {
        public ulong Generation { get; set; } = 1;
        public ushort SleepMilliseconds { get; set; } = 1000;
        public bool IsPaused = false;
        public T Printer = new T();

        public List<GameController<T>> GameControllers { get; set; } = new List<GameController<T>>();

        /// <summary>
        /// 0 for continuous evolution, any other value specifies maximum amount of steps
        /// </summary>
        public ulong MaxGeneration { get; set; } = 0;
        public void Run()
        {
            SetUp();
            Thread thread = new Thread(new ParameterizedThreadStart(Process));
            thread.Start(IsPaused);
        }
        private void SetUp()
        {
            for(int i = 0; i < GameControllers.Count; i++)
            {
                //GameControllers[i].Printer.DialogSimple($"Editing the field #{i + 1}", false);
                GameControllers[i].EditField((uint)i + 1);
            }
        }
        private void Process(object paused)
        {
            bool isEnd;
            while (MaxGeneration == 0 || Generation <= MaxGeneration)
            {
                isEnd = true;
                if(!(bool)paused)
                {
                    Printer.Clear();
                    for (int i = 0; i < GameControllers.Count; i++)
                    {
                        GameControllers[i].Run();
                        isEnd &= GameControllers[i].IsEnd;
                    }
                    //Printer.DialogSimple($"Generation #{Generation}", false);
                    //Printer.GenerationMessage(Generation);
                    ShowGeneration();
                    Generation++;
                    Thread.Sleep(SleepMilliseconds);
                }
                if(isEnd)
                {
                    break;
                }
            }
        }
        private void ShowGeneration()
        {
            Printer.GenerationMessage(Generation);
        }
    }
}
