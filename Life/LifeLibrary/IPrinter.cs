using System.Collections.Generic;

namespace LifeLibrary
{
    public interface IPrinter
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void Clear();
        public void Print(bool[][] cells);
        public string DialogSimple(string message, bool answer, object sync = null);
        public string DialogWithOptions(List<string> options);
        public void FinishEditing();
    }
}
