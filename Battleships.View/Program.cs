using Battleships.Logic;
using System;

namespace Battleships.View
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulation = new Simulation();
            simulation.Run();
        }
    }
}
