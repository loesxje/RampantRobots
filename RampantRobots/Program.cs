using System;

namespace RampantRobots
{
    class Program
    { 
        static void Main(string[] args)
        {
            Factory factoryhall = new Factory(5, 10, 3);
            Mechanic Bob = new Mechanic(1,1);
            int Turns = 50;

            factoryhall.Draw(Bob);
            for (int i = 1; i <= Turns; i++)
            {
                string moves = factoryhall.MoveMechanic(Turns+1-i);
            }
            
            
            Console.ReadLine();
        }
    }
}
