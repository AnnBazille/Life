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
            throw new NotImplementedException();
        }

        public string DialogSimple(string message, bool answer, object sync = null)
        {
            throw new NotImplementedException();
        }

        public string DialogWithOptions(List<string> options)
        {
            throw new NotImplementedException();
        }

        public void FinishEditing()
        {
            throw new NotImplementedException();
        }

        public void Print(bool[][] cells)
        {
            throw new NotImplementedException();
        }
    }
}
