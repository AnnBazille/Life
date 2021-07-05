using System.Collections.Generic;

namespace LifeLibrary
{
    public interface IPrinter
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void Clear();
        public void Print(bool[][] cells, object target = null);
        public string DialogSimple(string message, bool answer, object sync = null);
        public string DialogWithOptions(List<string> options);
        public void FinishEditing(object target = null);
        public void GenerationMessage(ulong generation, object target = null);
        public void FieldMessage(string message, object target = null);
    }
}
