using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Logic.BoardLogic
{
    public class GenerateShips : IShipGenerator
    {
        public ICell Cell { get; set; } = new CellLogic();

        public async Task DrawShipsAsync(Cell firstPosition)
        {
            foreach (var ship in Ship.Ships)
            {
                PlaceShipOnBoard(firstPosition, ship);
                FindNextSpot();
            }
        }

        private void FindNextSpot()
        {
            throw new NotImplementedException();
        }

        private void PlaceShipOnBoard(Cell firstPosition, IShip ship)
        {
            if (ship.Size == 1)
               Cell.PointTypeDraw(DrawType.ShipMark, firstPosition);
        }
    }
}