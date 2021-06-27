using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public struct Position
    {
        public int X;
        public int Y;
    }
    class Cell
    {
        public Position Position { get; set; }
        public bool IsAlive { get; set; } = false;
        public void Process()
        {
            ;
        }
    }
}
