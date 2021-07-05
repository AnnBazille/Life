using System.Collections.Generic;
using System.Threading;

namespace LifeLibrary
{
    public class TimeController<T> where T : class, IPrinter, new()
    {
        public ulong Generation { get; set; } = 1;
        public ushort SleepMilliseconds { get; set; } = 1000;
        public bool IsPaused = false;
        public object SyncWindow;
        public T Printer = new T();

        public List<GameController<T>> GameControllers { get; set; } = new List<GameController<T>>();

        /// <summary>
        /// 0 for continuous evolution, any other value specifies maximum amount of steps
        /// </summary>
        public ulong MaxGeneration { get; set; } = 0;
        public void Run()
        {
            SetUp();
            //Thread thread = new Thread(new ParameterizedThreadStart(Process));
            //thread.Start(Status);
            Process();
        }
        private void SetUp()
        {
            for(int i = 0; i < GameControllers.Count; i++)
            {
                GameControllers[i].EditField((uint)i + 1);
            }
        }
        private void Process(/*object _status*/)
        {
            bool isEnd;
            //var status = _status as ThreadStatusArguments;
            while (MaxGeneration == 0 || Generation <= MaxGeneration)
            {
                isEnd = true;
                if(!IsPaused)
                {
                    Printer.Clear();
                    for (int i = 0; i < GameControllers.Count; i++)
                    {
                        GameControllers[i].Run();
                        isEnd &= GameControllers[i].IsEnd;
                    }
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
            Printer.GenerationMessage(Generation, SyncWindow);
        }
    }
}
