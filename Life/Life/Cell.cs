using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePrinterLibrary;

namespace Life
{
    public struct Position
    {
        public int X;
        public int Y;
    }
    public abstract class Cell<P> where P : class, IPrinter, new()
    {
        protected List<bool> CollectNeighbours()
        {
            List<bool> result = new List<bool>();
            var lastcopy = FieldController.FieldCopies.Last();
            //  *__
            //  _X_
            //  ___
            if (Position.X - 1 < 0 || Position.Y - 1 < 0)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * (Position.Y - 1) + (Position.X - 1);
                result.Add(lastcopy[idx]);
            }
            //  _*_
            //  _X_
            //  ___
            if (Position.Y - 1 < 0)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * (Position.Y - 1) + Position.X;
                result.Add(lastcopy[idx]);
            }
            //  __*
            //  _X_
            //  ___
            if (Position.X + 1 == FieldController.SizeX || Position.Y - 1 < 0)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * (Position.Y - 1) + (Position.X + 1);
                result.Add(lastcopy[idx]);
            }
            //  ___
            //  *X_
            //  ___
            if (Position.X - 1 < 0)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * Position.Y + (Position.X - 1);
                result.Add(lastcopy[idx]);
            }
            //  ___
            //  _X*
            //  ___
            if (Position.X + 1 == FieldController.SizeX)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * Position.Y + (Position.X + 1);
                result.Add(lastcopy[idx]);
            }
            //  ___
            //  _X_
            //  *__
            if (Position.X - 1 < 0 || Position.Y + 1 == FieldController.SizeY)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * (Position.Y + 1) + (Position.X - 1);
                result.Add(lastcopy[idx]);
            }
            //  ___
            //  _X_
            //  _*_
            if (Position.Y + 1 == FieldController.SizeY)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * (Position.Y + 1) + Position.X;
                result.Add(lastcopy[idx]);
            }
            //  ___
            //  _X_
            //  __*
            if (Position.X + 1 == FieldController.SizeX || Position.Y + 1 == FieldController.SizeY)
            {
                result.Add(false);
            }
            else
            {
                int idx = FieldController.SizeY * (Position.Y + 1) + (Position.X + 1);
                result.Add(lastcopy[idx]);
            }
            return result;
        }
        public Position Position { get; set; }
        public bool IsAlive { get; set; } = false;
        public FieldController<P> FieldController;
        abstract public void Process();
        abstract public Cell<P> GetInstance();
    }
    public class Cell233<P> : Cell<P> where P : class, IPrinter, new()
    {
        public override Cell<P> GetInstance()
        {
            return new Cell233<P>();
        }
        public override void Process()
        {
            var neighbours = CollectNeighbours();
            int alive = neighbours.Where(n => n == true).Count();
            if(IsAlive)
            {
                if (alive >= 2 && alive <= 3)
                {
                    IsAlive = true;
                }
                else
                {
                    IsAlive = false;
                }
            }
            else
            {
                if(alive == 3)
                {
                    IsAlive = true;
                }
                else
                {
                    IsAlive = false;
                }
            }
        }
    }
    public class Cell344<P> : Cell<P> where P : class, IPrinter, new()
    {
        public override Cell<P> GetInstance()
        {
            return new Cell344<P>();
        }
        public override void Process()
        {
            var neighbours = CollectNeighbours();
            int alive = neighbours.Where(n => n == true).Count();
            if (IsAlive)
            {
                if (alive >= 3 && alive <= 4)
                {
                    IsAlive = true;
                }
                else
                {
                    IsAlive = false;
                }
            }
            else
            {
                if (alive == 4)
                {
                    IsAlive = true;
                }
                else
                {
                    IsAlive = false;
                }
            }
        }
    }
    public class Cell234<P> : Cell<P> where P : class, IPrinter, new()
    {
        public override Cell<P> GetInstance()
        {
            return new Cell234<P>();
        }
        public override void Process()
        {
            var neighbours = CollectNeighbours();
            int alive = neighbours.Where(n => n == true).Count();
            if (IsAlive)
            {
                if (alive >= 2 && alive <= 4)
                {
                    IsAlive = true;
                }
                else
                {
                    IsAlive = false;
                }
            }
            else
            {
                if (alive == 3)
                {
                    IsAlive = true;
                }
                else
                {
                    IsAlive = false;
                }
            }
        }
    }
}
