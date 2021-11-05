using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.BoardLogic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Battleships.Logic
{
    public class Simulation
    {
        public IShootingMechanism ShootingMechanism { get; set; } = new ShootingMechanism();
        public ICell Cell { get; set; } = new CellLogic();
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
            //generuj po kolei każdy statek na planszy

            foreach (var player in Players)
                player.ShipGenerator.DrawShipsAsync(player);

            //Dwie plansze, player1, player2

            for (var i = 0; i < 2; i++)
                Board.DrawBoard();

            while (WinCondition)
            {
                ShootingMechanism.ShotMechanism(Player);
                Player2Shot();
            }

            //return winner;
        }
    }
}
