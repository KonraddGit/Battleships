using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.BoardLogic;
using System.Threading.Tasks;

namespace Battleships.Logic
{
    public class Simulation
    {
        public ICell Cell { get; set; } = new CellLogic();
        public IShipGenerator ShipGenerator { get; set; } = new GenerateShips();

        public async Task Run()
        {
            //pierwsza pozycja
            //generuj po kolei każdy statek na planszy

            ShipGenerator.DrawShipsAsync();



            Board.DrawBoard();

            //while (WinCondition)
            //{
            //    Player1Shot();
            //    Player2Shot();
            //}

            //return winner;
        }
    }
}
