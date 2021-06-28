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
        public Action StartProcess;
        public IPrinter Printer = new P();
        private Cell<P> Instance;
        private FieldController<P> fieldController;
        public bool IsEnd = false;
        public GameController(Cell<P> instance)
        {
            fieldController = new FieldController<P>(instance, this);
            Instance = instance;
        }
        public void Run()
        {
            Printer.Clear();
            Printer.Print(fieldController.FieldToArray());
            if (!IsFinish())
            {
                StartProcess();
            }
            else
            { 
                Printer.DialogSimple($"End of evolution.", false);
                IsEnd = true;
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
            for (int i = 0; i < fieldController.SizeY; i++)
            {
                for (int a = 0; a < fieldController.SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    if(fieldController.Field[position].IsAlive)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool IsLoopedField()
        {
            var lastcopy = fieldController.FieldCopies.Last();
            for(int i = 0; i < fieldController.FieldCopies.Count - 1; i++)
            {
                if (fieldController.FieldCopies[i].SequenceEqual(lastcopy))
                    return true;
            }
            return false;
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
            fieldController.ResizeField(/*StartProcess*/);
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
                do
                {
                    Printer.Print(fieldController.FieldToArray());
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
                                        if (!isOk || x < 0 || x >= fieldController.SizeX)
                                        {
                                            Printer.DialogSimple("Error: incorrect input", false);
                                        }
                                    } while (!isOk);
                                    int y;
                                    do
                                    {
                                        answer = Printer.DialogSimple("Y: ", true);
                                        isOk = int.TryParse(answer, out y);
                                        if (!isOk || y < 0 || y >= fieldController.SizeY)
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
                                        if (!isOk || x < 0 || x >= fieldController.SizeX)
                                        {
                                            Printer.DialogSimple("Error: incorrect input", false);
                                        }
                                    } while (!isOk);
                                    int y;
                                    do
                                    {
                                        answer = Printer.DialogSimple("Y: ", true);
                                        isOk = int.TryParse(answer, out y);
                                        if (!isOk || y < 0 || y >= fieldController.SizeY)
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
                        if (option == 4)
                        { 
                            break;
                        }

                    }
                    Printer.Clear();
                } while (!isOk || option != 4);
            }
            //random
            else
            {
                fieldController.RandomFill();
                Printer.Print(fieldController.FieldToArray());
            }
            fieldController.SaveField();
        }
    }
}
