using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Cell : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; } = false;
        public object Clone()
        {
            return new Cell()
            {
                X = this.X,
                Y = this.Y,
                IsAlive = this.IsAlive
            };
        }
        public void Process()
        {
            ;
        }
    }
}
