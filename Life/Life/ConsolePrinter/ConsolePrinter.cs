using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life.ConsolePrinter
{
    class ConsolePrinter : IPrinter
    {
        public ConsolePrinter()
        {
            Field idx = new Field() { Name = "idx" };
            tc.Table.Fields.Add(idx);
            tc.Table.Name = "Conway's Game of Life";
        }
        private TableController tc = new TableController();
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
                    tc.Table.Fields.Add(field);
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
        public void Print(List<Cell> cells)
        {
            Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(Info);
            for(int i = 0; i < cells.Count; i++)
            {
                if(cells[i].IsAlive)
                {
                    tc.Table.Entries[cells[i].Y].Columns[fields[cells[i].X + 1]] = "▆";
                }
                else
                {
                    tc.Table.Entries[cells[i].Y].Columns[fields[cells[i].X + 1]] = " ";
                }
            }
            Console.WriteLine(tc.GetTextTable());
        }
        public string Dialog(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine();
            return answer;
        }
    }
}
