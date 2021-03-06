﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RampantRobots
{
    class Robot
    {
        static Random random = new Random();
        public int xPos { get; set; }
        public int yPos { get; set; }

        // Constructor
        public Robot(int xPosition, int yPosition)
        {
            xPos = xPosition;
            yPos = yPosition;
        }

        public void Move(string moves, bool robotsMove)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (robotsMove)
                {
                    int rand = random.Next(1, 5);
                    switch (rand)
                    {
                        case 1:
                            xPos++;
                            break;
                        case 2:
                            xPos--;
                            break;
                        case 3:
                            yPos++;
                            break;
                        case 4:
                            yPos--;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Robot))
                return false;

            return (this.xPos == ((Robot)obj).xPos & this.yPos == ((Robot)obj).yPos);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
