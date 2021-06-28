using System.Collections.Generic;
using System.Threading;
using ConsolePrinterLibrary;

namespace Life
{
    public class TimeController<T> where T : class, IPrinter, new()
    {
        public ulong Generation { get; private set; } = 1;
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
                GameControllers[i].Printer.DialogSimple($"Editing the field #{i + 1}", false);
                GameControllers[i].EditField();
            }
        }
        private void Process(object paused)
        {
            bool NextStep = false;
            while (MaxGeneration == 0 || Generation <= MaxGeneration)
            {
                if(!(bool)paused)
                {
                    for (int i = 0; i < GameControllers.Count; i++)
                    {
                        if (!GameControllers[i].IsEnd)
                        {
                            GameControllers[i].Run();
                        }
                        NextStep |= GameControllers[i].IsEnd;
                    }
                    Printer.DialogSimple($"Generation #{Generation}", false);
                    Generation++;
                    Thread.Sleep(SleepMilliseconds);
                }
                if(NextStep)
                {
                    break;
                }
            }
        }
    }
}
