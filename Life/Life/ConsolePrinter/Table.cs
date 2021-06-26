using System.Collections.Generic;

namespace Life.ConsolePrinter
{
    class Table
    {
        public string Name { get; set; } = string.Empty;
        public List<Entry> Entries { get; set; } = new List<Entry>();
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}
