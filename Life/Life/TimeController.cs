using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ConsolePrinterLibrary;

namespace Life
{
    public class TimeController<T> where T : class, IPrinter, new()
    {
        public ulong Generation { get; private set; } = 1;
        public ushort SleepMilliseconds { get; set; } = 1000;
        public bool IsPaused = false;
        public List<GameController<T>> GameControllers { get; set; } = new List<GameController<T>>();
        /// <summary>
        /// 0 for continuous evolution, any other value specifies maximum amount of steps
        /// </summary>
        public ulong MaxGeneration { get; set; } = 0;

        public void Run()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Process));
            thread.Start(IsPaused);
        }
        private void Process(object paused)
        {
            while (MaxGeneration == 0 || Generation <= MaxGeneration)
            {
                if(!(bool)paused)
                {
                    Thread.Sleep(SleepMilliseconds);
                    for (int i = 0; i < GameControllers.Count; i++)
                    {
                        GameControllers[i].StartProcess();
                    }
                }
            }
        }
    }
}
