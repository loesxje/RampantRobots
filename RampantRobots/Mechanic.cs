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
                if (moves[i] == 'w')
                {
                    yPos--;
                }
                else if (moves[i] == 's')
                {
                    yPos++;
                }
                else if (moves[i] == 'a')
                {
                    xPos--;
                }
                else if (moves[i] == 'd')
                {
                    xPos++;
                }
                else
                {
                    Console.WriteLine("You gave in some wrong input.  Move only with the w,a,s,d keys.");
                }
            }
            
        }
    }
}
