using Battleships.Logic;
using System;

namespace Battleships.View
{
    class Program
    {
        static void Main(string[] args)
        { 
            var simulation = new Simulation();

            //Console.WriteLine("Enter the number of simulations to be run");

            //var runCount = Convert.ToInt32(Console.ReadLine());

            //if (runCount < 1)
            //    Environment.Exit(0);

            //for (int i = 0; i < runCount; i++)
                simulation.Run();

            //var winner = simulation.Run();
            //Console.WriteLine($"Well done {winner.Name}! You Won!");
        }
    }
}
