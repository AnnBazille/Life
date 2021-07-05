using System.Collections.Generic;

namespace LifeLibrary
{
    public interface IPrinter
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public object Target { get; set; }
        public void Clear();
        public void Print(bool[][] cells);
        public string DialogSimple(string message, bool answer, object sync = null);
        public string DialogWithOptions(List<string> options);
        public void StartEditing();
        public void FinishEditing(object syncfield);
        public void GenerationMessage(ulong generation, object target = null);
        public void FieldMessage(string message);
    }
}
