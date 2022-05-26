using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    public class Food
    {
        public Point Position;
        public bool IsEaten;
        public Food()
        {
            Position = new Point(30, 15);
            IsEaten = true;
        }

        public void Update()
        {
            Position.X = new Random().Next(0, Game.WindowWidth + 1);
            Position.Y = new Random().Next(0, Game.WindowHeight + 1);
        }


    }
}
