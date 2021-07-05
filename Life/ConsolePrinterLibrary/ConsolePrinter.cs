using System;
using System.Collections.Generic;
using LifeLibrary;

namespace ConsolePrinterLibrary
{
    public class ConsolePrinter : IPrinter
    {
        public ConsolePrinter()
        {
            tp.Table.Name = "Conway's Game of Life";
        }
        private TablePrinter tp = new TablePrinter();
        private List<Field> fields = new List<Field>();
        private List<Entry> entries = new List<Entry>();
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                for(int i = -1; i < _width; i++)
                {
                    Field field;
                    if (i == -1)
                    {
                        field = new Field() { Name = "idx" };
                    }
                    else
                    {
                        field = new Field() { Name = $"{i}" }; 
                    }
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
                    for(int a = 0; a < _width + 1; a++)
                    {
                        if(a == 0)
                        {
                            entry.Columns.Add(fields[a], $"{i}");
                        }
                        else
                        {
                            entry.Columns.Add(fields[a], " ");
                        }
                    }
                    tp.Table.Entries.Add(entry);
                }
            }
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void Print(bool[][] cells)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for(int i = 0; i < cells.Length; i++)
            {
                for(int a = 0; a < cells[i].Length; a++)
                {
                    if(cells[i][a])
                    {
                        tp.Table.Entries[i].Columns[fields[a + 1]] = "*";
                    }
                    else
                    {
                        tp.Table.Entries[i].Columns[fields[a + 1]] = " ";
                    }
                }
            }
            Console.WriteLine(tp.GetTextTable());
        }
        public string DialogSimple(string message, bool answer, object sync = null)
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

        public void FinishEditing()
        {
            DialogSimple("Editing is finished.", false);
        }

        public void GenerationMessage(ulong generation)
        {
            Console.WriteLine($"Generation #{generation}");
        }

        public void FieldMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
