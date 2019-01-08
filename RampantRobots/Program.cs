using System;

namespace RampantRobots
{
    class Program
    { 
        static void Main(string[] args)
        {
            Factory factoryhall = new Factory(5, 10, 3, 50, true);
            factoryhall.Run();
        }
    }
}
