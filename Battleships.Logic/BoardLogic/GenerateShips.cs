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

        public async Task DrawShipsAsync()
        {
            foreach (var ship in Ship.Ships)
                PlaceShipOnBoard(ship);
        }

        private Cell FindNextSpot(List<Cell> cell = null)
        {
            var newPosition = Cell.FirstPosition();

            if (cell == null)
                return newPosition;

            foreach (var position in cell)
                if (position == newPosition)
                    FindNextSpot(cell);

            foreach (var position in cell)
                if (!SpaceBetweenShips(position, newPosition))
                    FindNextSpot(cell);

            return newPosition;
        }

        private bool SpaceBetweenShips(Cell cell, Cell newPosition)
        {
            if (newPosition.X == cell.X + 1 && newPosition.Y == cell.Y + 1
                || (newPosition.X == cell.X && newPosition.Y == cell.Y + 1)
                || (newPosition.X == cell.X && newPosition.Y == cell.Y - 1)
                || (newPosition.X == cell.X + 1 && newPosition.Y == cell.Y)
                || (newPosition.X == cell.X - 1 && newPosition.Y == cell.Y)
                || (newPosition.X == cell.X + 1 && newPosition.Y == cell.Y - 1)
                || (newPosition.X == cell.X - 1 && newPosition.Y == cell.Y - 1)
                || (newPosition.X == cell.X - 1 && newPosition.Y == cell.Y + 1)
                )
                return false;
            else
                return true;
        }

        private void PlaceShipOnBoard(IShip ship)
        {
            var placedShips = new List<Cell>();

            for (int i = 0; i < ship.ShipNumber; i++)
                switch (ship.Size)
                {
                    case 1:
                        placedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(placedShips)));
                        break;

                    case 2:
                        //Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(first));
                        //var direction = rnd.Next(1, 4);

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

