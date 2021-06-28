using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ConsolePrinterLibrary;

namespace Life
{
    public class GameController<T> where T : class, IPrinter, new()
    {
        private Timer Timer = new Timer(1000);
        public Action StartProcess;
        private Dictionary<Position, Cell> Field = new Dictionary<Position, Cell>();
        public List<bool[]> FieldCopies = new List<bool[]>();
        public int SizeY { get; private set; }
        public int SizeX { get; private set; }
        public ulong Generation { get; private set; } = 1;
        private IPrinter Printer;
        public bool IsPaused { get; private set; }
        public GameController() 
        {
            Printer = new T();
        }
        private bool[][] FieldToArray()
        {
            bool[][] array = new bool[SizeY][];
            for(int i = 0; i < SizeY; i++)
            {
                array[i] = new bool[SizeX];
                for(int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    if(Field[position].IsAlive)
                    {
                        array[i][a] = true;
                    }
                    else
                    {
                        array[i][a] = false;
                    }
                }
            }
            return array;
        }
        private bool[] SimplifyFieldArray(bool[][] source)
        {
            bool[] result = new bool[SizeY * SizeX];
            for(int i = 0; i < SizeY; i++)
            {
                for(int a= 0; a < SizeX; a++)
                {
                    result[i * SizeY + SizeX] = source[i][a];
                }
            }
            return result;
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
                Printer.DialogSimple($"The evolution has ended. Generation #{Generation}", false);
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
            Printer.Print(FieldToArray());
        }
        private void ChangePauseState()
        {
            IsPaused = !IsPaused;
        }
        private void ClearField()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for(int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    Field[position].IsAlive = false;
                }
            }
        }
        private void ResizeField()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    Cell cell = new Cell();
                    cell.Position = position;
                    Field.Add(position, cell);
                    StartProcess += () => cell.Process();
                }
            }
        }
        private void SetCell(int x, int y, bool state = true)
        {
            Position position;
            position.X = x;
            position.Y = y;
            Field[position].IsAlive = state;
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
                    Position position;
                    position.Y = idx / SizeY;
                    position.X = idx - SizeY * position.Y;
                    Field[position].IsAlive = true;
                }
            }
        }
        private void EditField()
        {
            string answer;
            bool isOk;
            do
            {
                answer = Printer.DialogSimple("Width: ", true);
                isOk = uint.TryParse(answer, out _);
                if(!isOk)
                {
                    Printer.DialogSimple("Error: incorrect input", false);
                }
            } while (!isOk);
            SizeX = int.Parse(answer);
            Printer.Width = SizeX;
            do
            {
                answer = Printer.DialogSimple("Height: ", true);
                isOk = int.TryParse(answer, out _);
                if (!isOk)
                {
                    Printer.DialogSimple("Error: incorrect input", false);
                }
            } while (!isOk);
            SizeY = int.Parse(answer);
            Printer.Height = SizeY;
            ResizeField();
            StartProcess += () => SaveField();
            int option;
            do
            {
                List<string> options = new List<string>();
                options.Add("Fill the field manually");
                options.Add("Fill the field randomly");
                answer = Printer.DialogWithOptions(options);
                isOk = int.TryParse(answer, out option);
                if(!isOk || (option != 1 && option != 2))
                {
                    isOk = false;
                    Printer.DialogSimple("Error: incorrect input", false);
                }
            } while (!isOk);
            //manual
            if(option == 1)
            {
                Printer.Print(FieldToArray());
                do
                {
                    List<string> options = new List<string>();
                    options.Add("Set cell");
                    options.Add("Unset cell");
                    options.Add("Clear");
                    options.Add("Finish editing");
                    answer = Printer.DialogWithOptions(options);
                    isOk = int.TryParse(answer, out option);
                    if (!isOk || (option != 1 && option != 2 && option != 3 && option != 4))
                    {
                        isOk = false;
                        Printer.DialogSimple("Error: incorrect input", false);
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
                                        answer = Printer.DialogSimple("X: ", true);
                                        isOk = int.TryParse(answer, out x);
                                        if (!isOk || x < 0 || x >= SizeX)
                                        {
                                            Printer.DialogSimple("Error: incorrect input", false);
                                        }
                                    } while (!isOk);
                                    int y;
                                    do
                                    {
                                        answer = Printer.DialogSimple("Y: ", true);
                                        isOk = int.TryParse(answer, out y);
                                        if (!isOk || y < 0 || y >= SizeY)
                                        {
                                            Printer.DialogSimple("Error: incorrect input", false);
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
                                        answer = Printer.DialogSimple("X: ", true);
                                        isOk = int.TryParse(answer, out x);
                                        if (!isOk || x < 0 || x >= SizeX)
                                        {
                                            Printer.DialogSimple("Error: incorrect input", false);
                                        }
                                    } while (!isOk);
                                    int y;
                                    do
                                    {
                                        answer = Printer.DialogSimple("Y: ", true);
                                        isOk = int.TryParse(answer, out y);
                                        if (!isOk || y < 0 || y >= SizeY)
                                        {
                                            Printer.DialogSimple("Error: incorrect input", false);
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
