using System;
using System.Collections.Generic;

namespace LifeLibrary
{
    public class FieldController<P> where P : class, IPrinter, new()
    {
        public Dictionary<Position, Cell<P>> Field = new Dictionary<Position, Cell<P>>();
        private GameController<P> gameController;
        public List<bool[]> FieldCopies = new List<bool[]>();
        public int SizeY { get; set; }
        public int SizeX { get; set; }
        private Cell<P> Instance;
        public FieldController(Cell<P> instance, GameController<P> gc)
        {
            Instance = instance;
            gameController = gc;
        }
        public bool[][] FieldToArray()
        {
            bool[][] array = new bool[SizeY][];
            for (int i = 0; i < SizeY; i++)
            {
                array[i] = new bool[SizeX];
                for (int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    if (Field[position].IsAlive)
                    {
                        array[i][a] = true;
                    }
                    else
                    {
                        array[i][a] = false;
                    }
                }
            }
            return array;
        }
        public bool[] SimplifyFieldArray(bool[][] source)
        {
            bool[] result = new bool[SizeY * SizeX];
            for (int i = 0; i < SizeY; i++)
            {
                for (int a = 0; a < SizeX; a++)
                {
                    result[i * SizeY + a] = source[i][a];
                }
            }
            return result;
        }
        public void ResizeField()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    Cell<P> cell = Instance.GetInstance();
                    cell.Position = position;
                    cell.FieldController = this;
                    Field.Add(position, cell);
                    gameController.StartProcess += () => cell.Process();
                }
            }
        }
        public void SetCell(int x, int y, bool state = true)
        {
            Position position;
            position.X = x;
            position.Y = y;
            Field[position].IsAlive = state;
        }
        public void ClearField()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int a = 0; a < SizeX; a++)
                {
                    Position position;
                    position.X = a;
                    position.Y = i;
                    Field[position].IsAlive = false;
                }
            }
        }
        public void RandomFill()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int count = random.Next(SizeX * SizeY / 4, (SizeX * SizeY + 1) * 3 / 4);
            int center = SizeX * SizeY / 2 - 1;
            for (int i = 0; i < count; i++)
            {
                int idx = center + (int)(i * Math.Pow(-1, i));
                idx = Math.Abs(idx);
                idx %= SizeX * SizeY;
                int action = random.Next(0, 2);
                if (action == 1)
                {
                    Position position;
                    position.Y = idx / SizeY;
                    position.X = idx - SizeY * position.Y;
                    Field[position].IsAlive = true;
                }
            }
        }
        public void SaveField()
        {
            FieldCopies.Add(SimplifyFieldArray(FieldToArray()));
        }
    }
}
