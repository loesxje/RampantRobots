using System;
using System.Collections.Generic;
using System.Text;

namespace RampantRobots
{
    class Factory
    {
        static Random random = new Random(42);
        public int Height { get; set; }
        public int Width { get; set; }
        public int Turns { get; set; }
        Mechanic Bob = new Mechanic(1, 1);
        public List<Robot> robots;
    

        // Constructor
        public Factory(int height, int width, int xRobots, int turns)
        {
            Height = height;
            Width = width;
            Turns = turns;
            robots = new List<Robot>();
            for (int i = 0; i < xRobots; i++)
            {
                Robot newRobot = new Robot(random.Next(1, width), random.Next(1, height));
                if (robots.Contains(newRobot) | (newRobot.xPos == Bob.xPos & newRobot.yPos == Bob.yPos))
                {
                    i--;
                }
                else
                {
                    robots.Add(newRobot);
                }
            }
        }

        public void Draw(Mechanic Bob)
        {
            StringBuilder sb = new StringBuilder();

            for (int h = 1; h <= Height; h++)
            {
                for (int l = 1; l <= Width; l++)
                {
                    var locRobot = new Robot(l, h);
                    if (Bob.xPos == l & Bob.yPos == h)
                    {
                        sb.Append('M');
                    }
                    else if (robots.Contains(locRobot))
                    {
                        sb.Append('R');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());

        }

        public void MoveMechanic()
        {
            for (int i = 1; i <= Turns; i++)
            {
                Console.WriteLine("Press Enter to continue");
                string moves = Console.ReadLine();
                Bob.Move(moves);
                Draw(Bob);
                Console.WriteLine(String.Format("You've got {0} turns left.", Turns - i));
            }
        }

        // TO DO: 
        // Mechanic can go out of bounds (Bob.Pos > 1 & Bob.Pos < Heigth / Width)
        // Mechanic can stand on Robot, but Robot don't dissappear (na draw (if Bob.Pos == robots.Pos --> delete that robot)
        // Robots don't move (per length moves, make random +- 1 in xPos or yPos of robots)
        // Robots can go out of bounds (robots.Pos& Bob.Pos < Heigth / Width)
        // Maybe refresh output instead of putting it under it (clear screen somehow, then Draw() method)
    }
}
