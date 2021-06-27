using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePrinterLibrary
{
    public class ConsolePrinter : IPrinter
    {
        public ConsolePrinter()
        {
            Field idx = new Field() { Name = "idx" };
            tp.Table.Fields.Add(idx);
            tp.Table.Name = "Conway's Game of Life";
        }
        private TablePrinter tp = new TablePrinter();
        private List<Field> fields = new List<Field>();
        private List<Entry> entries = new List<Entry>();
        public string Info { get; set; }
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                for(int i = 0; i < _width; i++)
                {
                    Field field = new Field() { Name = $"{i}" };
                    fields.Add(field);
                    tp.Table.Fields.Add(field);
                }
            }
        }
        private int _heigth;
        public int Height 
        {
            get => _heigth;
            set
            {
                _heigth = value;
                for(int i = 0; i < _heigth; i++)
                {
                    Entry entry = new Entry();
                    for(int a = 0; a < _width; a++)
                    {
                        entry.Columns.Add(fields[a], " ");
                    }
                }
            }
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void Print(bool[][] cells)
        {
            Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(Info);
            for(int i = 0; i < cells.Length; i++)
            {
                for(int a = 0; a < cells[i].Length; a++)
                {
                    if(cells[i][a])
                    {
                        tp.Table.Entries[i].Columns[fields[a + 1]] = "▆";
                    }
                    else
                    {
                        tp.Table.Entries[i].Columns[fields[a + 1]] = " ";
                    }
                }
            }
            Console.WriteLine(tp.GetTextTable());
        }
        public string DialogSimple(string message, bool answer)
        {
            Console.WriteLine(message);
            string result = string.Empty;
            if (answer)
                result = Console.ReadLine();
            return result;
        }

        public string DialogWithOptions(List<string> options)
        {
            string result = string.Empty;
            for(int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. - {options[i]}");
            }
            result = Console.ReadLine();
            return result;
        }
    }
}
