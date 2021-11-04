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
        private static readonly Random rnd = new();

        public async Task DrawShipsAsync(Cell firstPosition)
        {
            foreach (var ship in Ship.Ships)
            {
                PlaceShipOnBoard(firstPosition, ship);
            }
        }

        private Cell FindNextSpot(Cell cell = null)
        {
            var newPosition = Cell.FirstPosition();

            if (cell == null)
                return newPosition;

            if (cell == newPosition)
                FindNextSpot(cell);

            if (cell.X + 1 == newPosition.X
                || cell.Y + 1 == newPosition.Y
                || cell.X - 1 == newPosition.X
                || cell.Y - 1 == newPosition.Y
                )
                FindNextSpot(cell);

            return newPosition;
        }

        private void PlaceShipOnBoard(Cell firstPosition, IShip ship)
        {
            Cell first = null;

            for (int i = 0; i < ship.ShipNumber; i++)
                switch (ship.Size)
                {
                    case 1:
                        if (i < 1)
                            first = Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot());
                        else
                            Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(first));
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    default:
                        break;
                }
        }
    }
}

