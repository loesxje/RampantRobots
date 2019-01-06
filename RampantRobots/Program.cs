using System;

namespace RampantRobots
{
    class Program
    { 
        static void Main(string[] args)
        {
            Factory factoryhall = new Factory(5, 10, 1);
            factoryhall.Run();


        }
    }
}
