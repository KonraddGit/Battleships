using Battleships.Core.Models;

namespace Battleships.Logic.Helpers
{
    public static class Extensions
    {
        public static bool CheckForFreeSpace(this Cell cell, Player player)
        {
            if (player.GameBoard[cell.X + 1, cell.Y + 1] == 0
                || (player.GameBoard[cell.X, cell.Y + 1] == 0)
                || (player.GameBoard[cell.X, cell.Y - 1] == 0)
                || (player.GameBoard[cell.X + 1, cell.Y] == 0)
                || (player.GameBoard[cell.X - 1, cell.Y] == 0)
                || (player.GameBoard[cell.X + 1, cell.Y - 1] == 0)
                || (player.GameBoard[cell.X - 1, cell.Y - 1] == 0)
                || (player.GameBoard[cell.X - 1, cell.Y + 1] == 0)
                )
                return true;
            else
                return false;
        }
    }
}
