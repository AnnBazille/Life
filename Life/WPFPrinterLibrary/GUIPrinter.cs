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

namespace WPFPrinterLibrary
{
    public class GUIPrinter : IPrinter
    {
        public int Width { get; set ; }
        public int Height { get; set; }

        public void Clear() { }

        public string DialogSimple(string message, bool answer, object sync = null)
        {
            String result = string.Empty;
            if(answer)
            {
                InputWindow window = new InputWindow(message, result);
                window.ShowDialog();
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
            String result = string.Empty;
            SelectWindow window = new SelectWindow(options, result);
            window.ShowDialog();
            return result;
        }

        public void FieldMessage(string message, object target = null)
        {
            var window = target as FieldWindow;
            window.FieldMessage.Text = message;
        }

        public void FinishEditing(object target = null)
        {
            var window = target as FieldWindow;
            window.LockCells();
        }

        public void GenerationMessage(ulong generation, object target = null)
        {
            var window = target as FieldWindow;
            window.FieldMessage.Text = $"Generation #{generation}";
        }

        public void Print(bool[][] cells, object target = null)
        {
            var window = target as FieldWindow;
            for(int i = 0; i < Height; i++)
            {
                for(int a = 0; a < Width; a++)
                {
                    if(cells[i][a])
                    {
                        window.Buttons[i * Height + a * Width].Background = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        window.Buttons[i * Height + a * Width].Background = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }
    }
}
