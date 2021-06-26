using System.Collections.Generic;

namespace Life
{
    interface IPrinter
    {
        public string Info { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void Clear();
        public void Print(List<Cell> cells);
        public string Dialog(string message);
    }
}
