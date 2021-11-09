using Battleships.Core.Models;
using System;

namespace Battleships.Logic.Helpers
{
    public static class Extensions
    {
        private static readonly Random rnd = new();
        
        public static int RandomDirection()
            => rnd.Next(0, 3);

        public static bool CheckForFreeSpace(this Cell cell, Player player)
        {
            if (player.GameBoard[cell.X + 1, cell.Y + 1] == 0
                && (player.GameBoard[cell.X, cell.Y + 1] == 0)
                && (player.GameBoard[cell.X, cell.Y - 1] == 0)
                && (player.GameBoard[cell.X + 1, cell.Y] == 0)
                && (player.GameBoard[cell.X - 1, cell.Y] == 0)
                && (player.GameBoard[cell.X + 1, cell.Y - 1] == 0)
                && (player.GameBoard[cell.X - 1, cell.Y - 1] == 0)
                && (player.GameBoard[cell.X - 1, cell.Y + 1] == 0)
                )
                return true;
            else
                return false;
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
