using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    public class Snake
    {
        public List<Point> Position;
        public Snake()
        {
            var rnd = new Random();
            Position = new List<Point>() { new Point(rnd.Next(0, Game.WindowWidth + 1), rnd.Next(0, Game.WindowHeight + 1)) };
            Position.Add(Position[0]);
        }
    }
}
