using System;
using System.Collections.Generic;
using System.Text;

namespace RampantRobots
{
    class Robot
    {
        public int xPos { get; set; }
        public int yPos { get; set; }

        public Robot(int xPosition, int yPosition)
        {
            xPos = xPosition;
            yPos = yPosition;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Robot))
                return false;

            return (this.xPos == ((Robot)obj).xPos & this.yPos == ((Robot)obj).yPos);
        }
    }
}
