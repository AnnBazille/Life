using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLibrary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace WPFPrinterLibrary
{
    public class GUIPrinter : IPrinter
    {
        public int Width { get; set ; }
        public int Height { get; set; }
        public object Target { get; set; }
        public bool Lock { get; set; } = true;
        public string LastX{ get; set; }
        public string LastY { get; set; }
        public GUIPrinter()
        {
            Target = new FieldWindow(this);
        }
        public void Clear() { }
        public void StartEditing()
        {
            DialogSimple("Editing has started.", false);
            (Target as FieldWindow).SetSize(Width, Height);
            (Target as FieldWindow).Show();
        }
        public string DialogSimple(string message, bool answer, object sync = null)
        {
            String result = string.Empty;
            if (answer)
            {
                InputWindow window = new InputWindow(message);
                if (sync == null)
                { 
                    window.ShowDialog();
                    result = window.Answer;
                }
                else
                {
                    if(Lock)
                    {
                        (Target as FieldWindow).Activate();
                        //do something here
                        while(Lock) { }
                        result = LastX;
                    }
                    else
                    {
                        Lock = true;
                        result = LastY;
                    }
                }
            }
            else
            {
                MessageWindow window = new MessageWindow(message);
                window.ShowDialog();
            }
            return result;
        }

        public string DialogWithOptions(List<string> options)
        {
            SelectWindow window = new SelectWindow(options);
            window.ShowDialog();
            return window.Answer;
        }

        public void FieldMessage(string message)
        {
            (Target as FieldWindow).FieldMessage.Text = message;
        }

        public void FinishEditing(object syncfield)
        {
            var field = syncfield as FieldController<GUIPrinter>;
            //collect data
            var window = Target as FieldWindow;
            for(int i = 0; i < Height; i++)
            {
                for(int a = 0; a < Width; a++)
                {
                    if((window.Buttons[i * Height + a].Tag as TagStatus).IsActivated)
                    {
                        field.SetCell(a, i);
                    }
                }
            }
            window.LockCells();
        }

        public void GenerationMessage(ulong generation, object target = null)
        {
            var window = target as MenuWindow;
            window.tbGeneration.Text = generation.ToString();
        }

        public void Print(bool[][] cells)
        {
            for(int i = 0; i < Height; i++)
            {
                for(int a = 0; a < Width; a++)
                {
                    if(cells[i][a])
                    {
                        (Target as FieldWindow).Buttons[i * Width + a].Background = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        (Target as FieldWindow).Buttons[i * Width + a].Background = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }
    }
}
