using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Life
{
    class GameController
    {
        private Timer Timer = new Timer(1000);
        private Action StartProcess;
        private List<Cell> Field = new List<Cell>();
        public List<List<Cell>> FieldCopies = new List<List<Cell>>();
        public int SizeY { get; private set; }
        public int SizeX { get; private set; }
        public ulong Generation { get; private set; } = 1;
        private IPrinter Printer = new Life.ConsolePrinter.ConsolePrinter();
        public bool IsPaused { get; private set; }
        private static GameController Controller;
        private GameController() { }
        public static GameController GetController()
        {
            if (Controller is null)
            {
                Controller = new GameController();
            }
            return Controller;
        }
        private void NextStep(object sender, EventArgs e)
        {
            if (StartProcess != null && !IsFinish() && !IsPaused)
            {
                Generation++;
                StartProcess();
            }
            else if(IsFinish())
            {
                Timer.Stop();
                Printer.Dialog($"The evolution has ended. Generation #{Generation}");
            }
        }
        private void SaveField()
        {
            ;
        }
        private bool IsFinish()
        {
            return true;
        }
        public void Run()
        {
            Timer.Elapsed += NextStep;
            EditField();
            Printer.Print(Field);
        }
        private void ChangePauseState()
        {
            IsPaused = !IsPaused;
        }
        private void ClearField()
        {
            for (int i = 0; i < Field.Count; i++)
            {
                Field[i].IsAlive = false;
            }
        }
        private void ResizeField()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int a = 0; a < SizeX; a++)
                {
                    Cell cell = new Cell()
                    {
                        Y = i,
                        X = a
                    };
                    Field.Add(cell);
                    StartProcess += () => cell.Process();
                }
            }
        }
        private void SetCell(int x, int y, bool state = true)
        {
            Field[SizeY * y + x].IsAlive = state;
        }
        private void RandomFill()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int count = random.Next(SizeX * SizeY / 4, (SizeX * SizeY + 1) * 3 / 4);
            int center = SizeX * SizeY / 2 - 1;
            for (int i = 0; i < count; i++)
            {
                int idx = center + (int)(i * Math.Pow(-1, i));
                idx = Math.Abs(idx);
                idx %= SizeX * SizeY;
                int action = random.Next(0, 2);
                if (action == 1)
                {
                    Field[idx].IsAlive = true;
                }
            }
        }
        private void EditField()
        {
            string answer;
            bool isOk;
            do
            {
                answer = Printer.Dialog("Width: ");
                isOk = int.TryParse(answer, out _);
                if(!isOk)
                {
                    Printer.Dialog("Error: incorrect input");
                }
            } while (!isOk);
            SizeX = int.Parse(answer);
            Printer.Width = SizeX;
            do
            {
                answer = Printer.Dialog("Height: ");
                isOk = int.TryParse(answer, out _);
                if (!isOk)
                {
                    Printer.Dialog("Error: incorrect input");
                }
            } while (!isOk);
            SizeY = int.Parse(answer);
            Printer.Height = SizeY;
            ResizeField();
            StartProcess += () => SaveField();
            int option;
            do
            {
                answer = Printer.Dialog("1. Fill the field manually\r\n2. Fill the field randomly");
                isOk = int.TryParse(answer, out option);
                if(!isOk || (option != 1 && option != 2))
                {
                    isOk = false;
                    Printer.Dialog("Error: incorrect input");
                }
            } while (!isOk);
            //manual
            if(option == 1)
            {
                Printer.Print(Field);
                do
                {
                    answer = Printer.Dialog(
                        "1. Set cell\r\n" +
                        "2. Unset cell\r\n" +
                        "3. Clear\r\n" +
                        "4. Finish editing");
                    isOk = int.TryParse(answer, out option);
                    if (!isOk || (option != 1 && option != 2 && option != 3 && option != 4))
                    {
                        isOk = false;
                        Printer.Dialog("Error: incorrect input");
                    }
                    else
                    {
                        switch (option)
                        {
                            //set cell
                            case 1:
                                {
                                    int x;
                                    do
                                    {
                                        answer = Printer.Dialog("X: ");
                                        isOk = int.TryParse(answer, out x);
                                        if (!isOk || x < 0 || x >= SizeX)
                                        {
                                            Printer.Dialog("Error: incorrect input");
                                        }
                                    } while (!isOk);
                                    int y;
                                    do
                                    {
                                        answer = Printer.Dialog("Y: ");
                                        isOk = int.TryParse(answer, out y);
                                        if (!isOk || y < 0 || y >= SizeY)
                                        {
                                            Printer.Dialog("Error: incorrect input");
                                        }
                                    } while (!isOk);
                                    SetCell(x, y);
                                    break;
                                }
                            //unset cell
                            case 2:
                                {
                                    int x;
                                    do
                                    {
                                        answer = Printer.Dialog("X: ");
                                        isOk = int.TryParse(answer, out x);
                                        if (!isOk || x < 0 || x >= SizeX)
                                        {
                                            Printer.Dialog("Error: incorrect input");
                                        }
                                    } while (!isOk);
                                    int y;
                                    do
                                    {
                                        answer = Printer.Dialog("Y: ");
                                        isOk = int.TryParse(answer, out y);
                                        if (!isOk || y < 0 || y >= SizeY)
                                        {
                                            Printer.Dialog("Error: incorrect input");
                                        }
                                    } while (!isOk);
                                    SetCell(x, y, false);
                                    break;
                                }
                            case 3:
                                ClearField();
                                break;
                            default:
                                break;
                        }
                        //finish editing
                        Printer.Clear();
                        break;
                    }
                } while (!isOk);
            }
            //random
            else
            {
                RandomFill();
            }
        }
    }
}
