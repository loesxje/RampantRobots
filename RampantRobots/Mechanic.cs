using System;
using System.Collections.Generic;
using System.Text;

namespace RampantRobots
{

    class Mechanic
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int moves { get; set; }

        public Mechanic(int xPosition, int yPosition)
        {
            xPos = xPosition;
            yPos = yPosition;
        }

        public void Move(string moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'w':
                        yPos--;
                        break;
                    case 's':
                        yPos++;
                        break;
                    case 'a':
                        xPos--;
                        break;
                    case 'd':
                        xPos++;
                        break;
                    default:
                        Console.WriteLine("You gave in some wrong input.  Move only with the w,a,s,d keys.");
                        break;
                }                   
            }
            
        }
    }
}
