using Battleships.Core.Models;
using Battleships.Logic.BoardLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Battleships.Logic
{
    public class Simulation
    {
        public ShipGenerator ShipGenerator { get; set; } = new ShipGenerator();
        public ShootingGenerator ShootingGenerator { get; set; } = new ShootingGenerator();

        public static Player player1 = new Player { Id = 1, Name = "Johnny" };
        public static Player player2 = new Player { Id = 2, Name = "Obama" };

        public List<Player> Players = new()
        {
            player1,
            player2
        };

        public void Run()
        {
            foreach (var player in Players)
            {
                ShipGenerator.DrawShipsAsync(player);
                player.HitPoints = player.PlacedShips.Count;
            }

            while (true)
            {
                foreach (var player in Players)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                    DrawBoard();

                    if (FinishGame(player))
                        return;

                    ShootingGenerator.ShotEnemy(player);
                }
            }
        }

        private bool FinishGame(Player player)
        {
            if (player.HitPoints == 0)
            {
                Console.WriteLine($"{player.Name} LOST!");
                return true;
            }

            return false;
        }

        private void DrawBoard()
        {
            foreach (var player in Players)
            {
                Console.WriteLine(player.Name);
                Board.DrawBoard(player);
                Console.WriteLine("\n\n\n");
            }
        }
    }
}
