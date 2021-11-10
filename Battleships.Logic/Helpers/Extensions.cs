using Battleships.Core.Models;
using System;
using System.Collections.Generic;

namespace Battleships.Logic.Helpers
{
    public static class Extensions
    {
        private static readonly Random rnd = new();

        public static int RandomDirection()
            => rnd.Next(0, 3);

        public static bool TargetOutOfMap(Cell cell)
        {
            if (cell.X < 0
                || cell.X > 10
                || cell.Y < 0
                || cell.Y > 10)
                return true;

            return false;
        }

        public static List<Cell> IterateAroundCell(Cell cell)
            => new List<Cell>()
            {
                new Cell { X = cell.X + 1, Y = cell.Y + 1},
                new Cell { X = cell.X, Y = cell.Y + 1},
                new Cell { X = cell.X, Y = cell.Y - 1},
                new Cell { X = cell.X + 1, Y = cell.Y},
                new Cell { X = cell.X - 1, Y = cell.Y},
                new Cell { X = cell.X + 1, Y = cell.Y - 1},
                new Cell { X = cell.X - 1, Y = cell.Y - 1},
                new Cell { X = cell.X - 1, Y = cell.Y + 1}
            };

        public static bool CheckForFreeSpace(this Cell cell, Player player)
        {
            try
            {
                foreach (var item in IterateAroundCell(cell))
                    if (player.GameBoard[item.X, item.Y] == 0)
                        continue;
                    else
                        return false;
            }
            catch (Exception)
            {
                throw new Exception("Bug");
            }

            return true;
        }

        public static bool CheckForFreeSpace(Cell cell, Cell newPosition)
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
    }
}
