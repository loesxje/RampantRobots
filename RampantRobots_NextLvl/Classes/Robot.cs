namespace RampantRobots_NextLvl.Classes
{
    public class Robot
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Robot(int xPosition, int yPosition)
        {
            XPos = xPosition;
            YPos = yPosition;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Robot))
                return false;

            return (this.XPos == ((Robot)obj).XPos & this.YPos == ((Robot)obj).YPos);
        }
    }
}
