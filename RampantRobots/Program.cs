using System;

namespace RampantRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factoryhall = new Factory(5, 10, 3, 3);
            Mechanic Bob = new Mechanic(1,1);

            factoryhall.Draw(Bob);
            factoryhall.MoveMechanic();
            
            
            Console.ReadLine();
        }
    }
}
