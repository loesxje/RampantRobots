using System;
using System.Collections.Generic;
using System.Text;
using RampantRobots_NextLvl.Classes;

namespace RampantRobots_NextLvl
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Turns { get; set; }
        public List<Robot> Robots { get; set; }
    }
}
