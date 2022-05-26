using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Point operator +(Point a, Point b)
        {
            int x, y;
            if (a.X + b.X < 0)
            {
                x = Game.WindowWidth;
            }
            else if (a.X + b.X > Game.WindowWidth)
            {
                x = 0;
            }
            else
            {
                x = a.X + b.X;
            }
            if (a.Y + b.Y < 0)
            {
                y = Game.WindowHeight;
            }
            else if (a.Y + b.Y > Game.WindowHeight)
            {
                y = 0;
            }
            else
            {
                y = a.Y + b.Y;
            }
            return new Point(x, y);
        }

        public static bool operator ==(Point a, Point b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }

        public static bool operator !=(Point a, Point b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }
    }
}
