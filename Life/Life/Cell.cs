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
    public abstract class Cell
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
        public FieldController FieldController;
        abstract public void Process();
        abstract public Cell GetInstance();
    }
    public class Cell23 : Cell
    {
        public override Cell GetInstance()
        {
            return new Cell23();
        }
        public override void Process()
        {
            var neighbours = CollectNeighbours();
            int alive = neighbours.Where(n => n == true).Count();
            if (alive >= 2 && alive <= 3)
            { 
                IsAlive = true; 
            }
            else
            {
                IsAlive = false;
            }
        }
    }
    public class Cell34 : Cell
    {
        public override Cell GetInstance()
        {
            return new Cell34();
        }
        public override void Process()
        {
            var neighbours = CollectNeighbours();
            int alive = neighbours.Where(n => n == true).Count();
            if (alive >= 3 && alive <= 4)
            {
                IsAlive = true;
            }
            else
            {
                IsAlive = false;
            }
        }
    }
    public class Cell24 : Cell
    {
        public override Cell GetInstance()
        {
            return new Cell24();
        }
        public override void Process()
        {
            var neighbours = CollectNeighbours();
            int alive = neighbours.Where(n => n == true).Count();
            if (alive >= 2 && alive <= 4)
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
