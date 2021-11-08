using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Logic.BoardLogic
{
    public class GenerateShips : IShipGenerator
    {

        public static ICell Cell;
        
        private static readonly Random rnd = new();

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
                if (!SpaceBetweenShips(position, newPosition))
                    FindNextSpot(player);

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

        private void BuildShipWithGivenLength(Player player, int length)
        {
            var cell = player.PlacedShips.Last();
            Cell tmp = null;

            var direction = rnd.Next(0, 3);

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
                        player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(player)));
                        BuildShipWithGivenLength(player, ship.Size);
                        break;

                    case 3:
                        player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(player)));
                        BuildShipWithGivenLength(player, ship.Size);
                        break;

                    case 4:
                        player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, FindNextSpot(player)));
                        BuildShipWithGivenLength(player, ship.Size);
                        break;

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

