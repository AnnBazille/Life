using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ConsolePrinterLibrary;

namespace Life
{
    public class GameController<P> where P : class, IPrinter, new()
    {
        private Action StartProcess;
        private Dictionary<Position, Cell> Field = new Dictionary<Position, Cell>();
        public List<bool[]> FieldCopies = new List<bool[]>();
        public int SizeY { get; private set; }
        public int SizeX { get; private set; }
        public IPrinter Printer = new P();
        private Cell Instance;
        private FieldController fieldController;
        public GameController(Cell instance)
        {
            fieldController = new FieldController(instance);
            Instance = instance;
        }
        public void Run()
        {
            if (!IsFinish())
            {
                StartProcess();
            }
            else
            {
                Printer.DialogSimple($"End of evolution.", false);
            }
        }
        private bool IsFinish()
        {
            if (IsEmptyField() || IsLoopedField())
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsEmptyField()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    if(Field[position].IsAlive)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool IsLoopedField()
        {
            var lastcopy = FieldCopies.Last();
            for(int i = 0; i < FieldCopies.Count - 1; i++)
            {
                if (FieldCopies[i].SequenceEqual(lastcopy))
                    return false;
            }
            return true;
        }
        public void EditField()
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
            fieldController.SizeX = int.Parse(answer);;
            Printer.Width = fieldController.SizeX;
            do
            {
                answer = Printer.DialogSimple("Height: ", true);
                isOk = uint.TryParse(answer, out _);
                if (!isOk)
                {
                    Printer.DialogSimple("Error: incorrect input", false);
                }
            } while (!isOk);
            fieldController.SizeY = int.Parse(answer);
            Printer.Height = fieldController.SizeY;
            fieldController.ResizeField(StartProcess);
            StartProcess += () => fieldController.SaveField();
            int option;
            do
            {
                List<string> options = new List<string>();
                options.Add("Fill the field manually");
                options.Add("Fill the field randomly");
                answer = Printer.DialogWithOptions(options);
                isOk = int.TryParse(answer, out option);
                if(!isOk || !(option != 1 || option != 2))
                {
                    isOk = false;
                    Printer.DialogSimple("Error: incorrect input", false);
                }
            } while (!isOk);
            //manual
            if(option == 1)
            {
                Printer.Print(fieldController.FieldToArray());
                do
                {
                    List<string> options = new List<string>();
                    options.Add("Set cell");
                    options.Add("Unset cell");
                    options.Add("Clear");
                    options.Add("Finish editing");
                    answer = Printer.DialogWithOptions(options);
                    isOk = int.TryParse(answer, out option);
                    if (!isOk || !(option != 1 || option != 2 || option != 3 || option != 4))
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
                                    fieldController.SetCell(x, y);
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
                                    fieldController.SetCell(x, y, false);
                                    break;
                                }
                            case 3:
                                fieldController.ClearField();
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
                fieldController.RandomFill();
                Printer.Print(fieldController.FieldToArray());
            }
            fieldController.SaveField();
            ;
        }
    }
}
