using System.Collections.Generic;

namespace ConsolePrinterLibrary
{
    public interface IPrinter
    {
        public string Info { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void Clear();
        public void Print(bool[][] cells);
        public string DialogSimple(string message, bool answer);
        public string DialogWithOptions(List<string> options);
    }
}
