using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RampantRobots
{
    class Factory
    {
        static Random random = new Random(42);
        public int Height { get; set; }
        public int Width { get; set; }
        Mechanic Bob = new Mechanic(1, 1);
        public List<Robot> robots;
    

        // Constructor
        public Factory(int height, int width, int xRobots)
        {
            Height = height;
            Width = width;
            robots = new List<Robot>();
            for (int i = 0; i < xRobots; i++)
            {
                Robot newRobot = new Robot(random.Next(1, width), random.Next(1, height));
                if (robots.Contains(newRobot) | (newRobot.xPos == Bob.xPos & newRobot.yPos == Bob.yPos))
                    i--;

                else
                    robots.Add(newRobot);
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
                        sb.Append('M');
                    else if (robots.Contains(locRobot))
                        sb.Append('R');
                    else
                        sb.Append('.');
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());

        }

        public string MoveMechanic(int turns)
        {
                Console.WriteLine("Press Enter to continue");
                string moves = Console.ReadLine();
                Bob.Move(moves);

                // Don't let Bob go out of bounds
                if (Bob.yPos < 1)
                    Bob.yPos = 1;
                else if (Bob.xPos < 1)
                    Bob.xPos = 1;
                else if (Bob.yPos > Height)
                    Bob.yPos = Height;
                else if (Bob.xPos > Width)
                    Bob.xPos = Width;

                MoveRobots(moves);

                Console.Clear();

                Draw(Bob);
                Console.WriteLine(String.Format("You've got {0} turns left.", turns));
                return moves;
        }

        public void MoveRobots(string moves)
        {
            int[] originalxPos = new int[robots.Count];
            int[] originalyPos = new int[robots.Count];

            for (int i = robots.Count - 1; i >= 0; i--)
            {
                originalxPos[i] = robots[i].xPos;
                originalyPos[i] = robots[i].yPos;

                robots[i].Move(moves);
            }

            for (int i = 0; i < robots.Count; i++)
            {
                for (int j = 0; j < robots.Count; j++) // laatste robot wordt niet gecheckt
                {
                    if (i != j)
                    {
                        // Don't let the robots stand on eachother and dont let them go out of bounds
                        while ((robots[i].xPos == robots[j].xPos) & (robots[i].yPos == robots[j].yPos) |
                              (robots[i].yPos < 1) | (robots[i].xPos < 1) | (robots[i].yPos > Height) | (robots[i].xPos > Width))
                        {
                            // If so, make a new move for this robot with original positions
                            robots[i].xPos = originalxPos[i];
                            robots[i].yPos = originalyPos[i];
                            robots[i].Move(moves);
                        }
                    }
                }
            }
            KillRobot();
        }

        public void KillRobot()
        {
            for (int i = robots.Count-1; i >= 0; i--)
            {
                if (Bob.xPos == robots[i].xPos & Bob.yPos == robots[i].yPos)
                    robots.RemoveAt(i);
            }
        }

        // TO DO: 
        // Add a notice if the player has won.
        // Stop the game if the player has won.
        // Maybe add a highscore??
        // Add a description of the game in the beginnen. ( and maybe don't clear that description )

        // DOING:

        // DONE 05-01-2019
        // Keep track of turns
        // Maybe refresh output instead of putting it under it (clear screen somehow, then Draw() method)
        // I think the robots can stand on top of each other. Woopsie daisy..

        // DONE 02-01-2019
        // Mechanic not out of bounds
        // Mechanic can stand on Robot, but Robot don't dissappear (after draw (if Bob.Pos == robots.Pos --> delete that robot)
        // Robots don't move (per length moves, make random +- 1 in xPos or yPos of robots)
        // Robots can go out of bounds (robots.Pos& Bob.Pos < Heigth / Width)
    }
}
