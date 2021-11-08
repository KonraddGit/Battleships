using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.BoardLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Battleships.Logic
{
    public class Simulation
    {
        public IShootingMechanism ShootingMechanism { get; set; } = new ShootingMechanism();
        public IShipGenerator ShipGenerator { get; set; } = new GenerateShips();

        public static Player player1 = new Player { Id = 1, Name = "Johnny" };
        public static Player player2 = new Player { Id = 2, Name = "Obama" };

        public List<Player> Players = new()
        {
            player1,
            player2
        };

        public async Task Run()
        {
            // Generate Player Ships
            foreach (var player in Players)
                ShipGenerator.DrawShipsAsync(player);

            Console.WriteLine("\n\n");

            // Draw each players board
            foreach (var player in Players)
            {
                if (player == player1)
                {
                    Console.WriteLine(player.Name);
                    Board.DrawBoard(player);
                    Console.WriteLine("\n\n\n");
                }
                else
                {
                    Console.WriteLine(player.Name);
                    Board.DrawBoard(player);
                }
            }

            // Shooting until someone dies
            while (true)
                foreach (var player in Players)
                {
                    ShootingMechanism.Shot(player);
                    await Task.Delay(200);
                }
        }
    }
}
