using System;
using System.Collections.Generic;
using System.Text;

namespace RampantRobots
{
    class Factory
    {
        static Random random = new Random();
        public int Height { get; set; }
        public int Width { get; set; }
        Mechanic Bob = new Mechanic(1, 1);
        public List<Robot> robots;
        public int Turns { get; set; }
        public bool Robotsmove { get; set; }
    

        // Constructor
        public Factory(int height, int width, int xRobots, int turns, bool robotsMove)
        {
            Robotsmove = robotsMove;
            Turns = turns;
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
                for (int w = 1; w <= Width; w++)
                {
                    var locRobot = new Robot(w, h);
                    if (Bob.xPos == w & Bob.yPos == h)
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

        public void PlayRound(int turns, bool win)
        {
            Console.WriteLine("Press Enter to continue");
            string moves = Console.ReadLine();

            MoveMechanic(moves);
            MoveRobots(moves);

            Console.Clear();

            Draw(Bob);
            Console.WriteLine(String.Format("You've got {0} turns left.", turns));

            if (turns == 0)
            {
                Console.Clear();
                Console.WriteLine("YOU'VE LOST!");
                NewGame(win, turns);
            }

            win = WinCheck(win, turns);
            NewGame(win, turns);
        }

        public void Run()
        {
            Console.Clear();

            PrintDescription();

            Mechanic Bob = new Mechanic(1, 1);
            bool win = false;

            Draw(Bob);
            for (int i = Turns-1; i >= 0; i--)
            {
                PlayRound(i, win);
            }

            Console.ReadLine();
        }

        public void PrintDescription()
        {
            Console.WriteLine("Welcome to Rampant Robots.\n" +
                "The objective for this game is to reach and save all the robots, by giving them oil, before time runs out.\n" +
                "So you have to move quick!\nBut be aware that the robots also move when you do.\nGood luck out there!\n");
        }

        public void MoveMechanic(string moves)
        {
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
        }

        public void MoveRobots(string moves)
        {
            int[] originalxPos = new int[robots.Count];
            int[] originalyPos = new int[robots.Count];

            for (int i = robots.Count - 1; i >= 0; i--)
            {
                originalxPos[i] = robots[i].xPos;
                originalyPos[i] = robots[i].yPos;

                robots[i].Move(moves, Robotsmove);
            }

            CorrectRobots(originalxPos, originalyPos, moves);
            
            KillRobot();
        }
        
        public void CorrectRobots(int[] originalxPos, int[] originalyPos, string moves)
        {
            for (int i = 0; i < robots.Count; i++)
            {
                for (int j = 0; j < robots.Count; j++)
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
                            robots[i].Move(moves, Robotsmove);
                        }
                    }
                    else if (robots.Count == 1)
                    {
                        while ((robots[i].yPos < 1) | (robots[i].xPos < 1) | (robots[i].yPos > Height) | (robots[i].xPos > Width))
                        {
                            // If so, make a new move for this robot with original positions
                            robots[i].xPos = originalxPos[i];
                            robots[i].yPos = originalyPos[i];
                            robots[i].Move(moves, Robotsmove);
                        }
                    }
                }
            }
        }

        public void KillRobot()
        {
            for (int i = robots.Count-1; i >= 0; i--)
            {
                if (Bob.xPos == robots[i].xPos & Bob.yPos == robots[i].yPos)
                    robots.RemoveAt(i);
            }
        }

        public bool WinCheck(bool win, int turns)
        {
            if (robots.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("YOU'VE WON!");
                Console.WriteLine("You've had {0} turns left.", turns);
                win = true;
            }

            return win;
        }

        public void NewGame(bool win, int turns)
        {
            if (win == true | turns == 0)
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                string newgame = Console.ReadLine();

                if (newgame == "y")
                {
                    // I'd prefer to go directly to Main() or Program.cs
                    Factory factoryhall = new Factory(5, 10, 3, 10, true);
                    factoryhall.Run();
                }
                else if (newgame == "n")
                {
                    Console.WriteLine("Thanks for playing Rampant Robots!");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
            }
        }

        // TO DO: 

        // DOING:
        // Clean up code

        // DONE 08-01-2019
        // arg turns in Factory()
        // arg moveRobots in Factory()
        // "you lose" sign if out of turns
        // No robots at restart

        // DONE 06-01-2019
        // Add a notice if the player has won.
        // Stop the game if the player has won.
        // Add a description of the game in the beginning. ( and maybe don't clear that description )

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
