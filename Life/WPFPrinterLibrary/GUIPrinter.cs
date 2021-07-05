using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLibrary;

namespace WPFPrinterLibrary
{
    public class GUIPrinter : IPrinter
    {
        public int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Clear()
        {
            ;
        }

        public string DialogSimple(string message, bool answer, object sync = null)
        {
            ;
        }

        public string DialogWithOptions(List<string> options)
        {
            ;
        }

        public void FinishEditing()
        {
            ;
        }

        public void GenerationMessage(ulong generation)
        {
            throw new NotImplementedException();
        }

        public void Print(bool[][] cells)
        {
            ;
        }
    }
}
