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
        List<Cell> PlacedShips = new List<Cell>();
        public ICell Cell { get; set; } = new CellLogic();
        private static readonly Random rnd = new();

        public async Task DrawShipsAsync()
        {
            foreach (var ship in Ship.Ships)
                PlaceShipOnBoard(ship);
        }

        private Cell FindNextSpot()
        {
            var newPosition = Cell.FirstPosition();

            if (PlacedShips == null)
                return newPosition;

            foreach (var position in PlacedShips)
                if (position == newPosition)
                    FindNextSpot();

            foreach (var position in PlacedShips)
                if (!SpaceBetweenShips(position, newPosition))
                    FindNextSpot();

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

        private void BuildShipWithGivenLength(int length)
        {
            var cell = PlacedShips.Last();
            Cell tmp = null;

            var direction = rnd.Next(0, 3);
            switch (direction)
            {
                case 0:
                    tmp = new Cell { X = cell.X - 1, Y = cell.Y };
                    break;
                case 1:
                    tmp = new Cell { X = cell.X, Y = cell.Y + 1 };
                    break;
                case 2:
                    tmp = new Cell { X = cell.X + 1, Y = cell.Y };
                    break;
                case 3:
                    tmp = new Cell { X = cell.X, Y = cell.Y - 1 };
                    break;
                default:
                    break;
            }

            for (int i = 1; i < length; i++)
                PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, tmp));
        }

        private void PlaceShipOnBoard(IShip ship)
        {
            for (int i = 0; i < ship.ShipNumber; i++)
                switch (ship.Size)
                {
                    case 1:
                        PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot()));
                        break;

                    case 2:
                        PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot()));
                        BuildShipWithGivenLength(ship.Size);
                        break;

                    case 3:
                        PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot()));
                        BuildShipWithGivenLength(ship.Size);
                        break;

                    case 4:
                        PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot()));
                        BuildShipWithGivenLength(ship.Size);
                        break;

                    case 5:
                        PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot()));
                        BuildShipWithGivenLength(ship.Size);
                        break;

                    default:
                        break;
                }

            DisplayShipPositions(PlacedShips);
        }

        private static void DisplayShipPositions(List<Cell> placedShips)
        {
            foreach (var item in placedShips)
            {
                Console.WriteLine($"[{item.X}, {item.Y}]");
            }
        }
    }
}

