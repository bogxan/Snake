using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex2
{
    public class Game
    {
        enum Direction { Up, Down, Right, Left }
        private Direction direction;
        public int GameSpeed { get; private set; } = 60;
        private Snake snake;
        private Food food;
        private int countPoints = 0;
        static public int WindowWidth { get; private set; }
        static public int WindowHeight { get; private set; }
        private readonly Dictionary<Direction, Point> MoveTo = new Dictionary<Direction, Point>()
        {
            {Direction.Left, new Point(-1,0) },
            {Direction.Right, new Point(1,0) },
            {Direction.Up, new Point(0,-1) },
            {Direction.Down, new Point(0,1) }
        };

        public void Start()
        {
            DialogResult result = MessageBox.Show("Welcome in the game 'Snake'! Rules:\n" +
                "- you can lead snake using arrows on keyboard\n" +
                "- by eating fruit you will get 10 points\n" +
                "Start game?", "Snake", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    WindowWidth = Console.WindowWidth - 1;
                    WindowHeight = Console.WindowHeight - 2;
                    snake = new Snake();
                    food = new Food();
                    direction = Direction.Down;
                    while (true)
                    {
                        DrawMap();
                        Thread.Sleep(GameSpeed);
                        if (Console.KeyAvailable)
                        {
                            ChangeDirection(Console.ReadKey());
                        }
                    }
                case DialogResult.No:
                    Environment.Exit(0);
                    break;
            }   
        }

        private void DrawMap()
        {
            for (int i = 0; i < snake.Position.Count; i++)
            {
                Console.SetCursorPosition(snake.Position[i].X, snake.Position[i].Y);
                if (i + 1 < snake.Position.Count)
                {
                    Console.Write("*");
                }  
                else
                {
                    Console.Write(" ");
                }   
            }
            Move();
            Console.SetCursorPosition(food.Position.X, food.Position.Y);
            Console.Write("@");
        }

        private void Move()
        {
            Task task1 = Task.Run(() =>
            {
                for (int i = snake.Position.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        snake.Position[i] += MoveTo[direction];
                        if (CheckGameOver())
                        {
                            Console.Clear();
                            MessageBox.Show($"You loose!!! You have got {countPoints} points!!!");
                            Environment.Exit(0);
                        }
                        else if (snake.Position[i] == food.Position)
                        {
                            if (GameSpeed > 15)
                            {
                                GameSpeed = GameSpeed - 1;
                            }
                            snake.Position.Add(snake.Position[snake.Position.Count - 1]);
                            Task task = Task.Run(() => { food.Update(); countPoints += 10; });
                        }
                    }
                    else
                    {
                        snake.Position[i] = snake.Position[i - 1];
                    }
                }
            });
        }

        private bool CheckGameOver()
        {
            var answer = false;
            for (int i = 1; i < snake.Position.Count; i++)
                if (snake.Position[i] == snake.Position[0])
                {
                    answer = true;
                }  
            return answer;
        }

        private void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.Down)
                    {
                        direction = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.Up)
                    {
                        direction = Direction.Down;
                    }
                    break;
            }
        }
    }
}
