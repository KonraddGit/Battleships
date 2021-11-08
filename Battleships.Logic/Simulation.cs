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
        //public ICell Cell { get; set; } = new CellLogic();
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
            //generuj po kolei każdy statek na planszy gracza

            foreach (var player in Players)
                ShipGenerator.DrawShipsAsync(player);
            Console.WriteLine("\n\n");
            //Dwie plansze, player1, player2

            foreach (var player in Players)
            {
                if (player == player1)
                {
                    Console.WriteLine("Player1");
                    Board.DrawBoard(player);
                    Console.WriteLine("\n\n\n");
                }
                else
                {
                    Console.WriteLine("Player2");
                    Board.DrawBoard(player);
                }
            }
            //while (WinCondition)
            //{
            //    for (int i = 0; i < 2; i++)
            //        ShootingMechanism.ShotMechanism(Players.);
            //    Player2Shot();
            //}

            //return winner;
        }
    }
}
