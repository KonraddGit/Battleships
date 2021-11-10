using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Logic.BoardLogic
{
    public class ShipGenerator
    {
        public static ICell Cell;

        public async Task DrawShipsAsync(Player player)
        {
            Cell = new CellLogic(player);

            foreach (var ship in Ship.Ships)
                PlaceShipOnBoard(player, ship);
        }

        private Cell FindNextSpot(Player player)
        {
            var newPosition = Cell.FirstPosition();

            if (player.PlacedShips == null)
                return newPosition;

            foreach (var position in player.PlacedShips)
                if (position == newPosition)
                    FindNextSpot(player);

            foreach (var position in player.PlacedShips)
                if (!Extensions.CheckForFreeSpace(position, newPosition))
                    FindNextSpot(player);

            return newPosition;
        }

        private void BuildShipWithGivenLength(Player player, int length)
        {
            var cell = player.PlacedShips.Last();
            Cell tmp = null;

            var direction = Extensions.RandomDirection();

            for (int i = 1; i < length; i++)
            {
                switch (direction)
                {
                    case 0:
                        tmp = new Cell { X = cell.X - i, Y = cell.Y };
                        break;
                    case 1:
                        tmp = new Cell { X = cell.X, Y = cell.Y + i };
                        break;
                    case 2:
                        tmp = new Cell { X = cell.X + i, Y = cell.Y };
                        break;
                    case 3:
                        tmp = new Cell { X = cell.X, Y = cell.Y - i };
                        break;
                    default:
                        break;
                }

                player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, tmp));
            }
        }

        private void PlaceShipOnBoard(Player player, IShip ship)
        {
            for (int i = 0; i < ship.ShipNumber; i++)
                switch (ship.Size)
                {
                    case 1:
                        player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(player)));
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(player)));
                        BuildShipWithGivenLength(player, ship.Size);
                        break;

                    default:
                        break;
                }

            //DisplayShipPositions(player.PlacedShips);
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

