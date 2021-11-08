using Battleships.Core.Models;
using System;

namespace Battleships.Logic.BoardLogic
{
    public static class Board
    {
        public static void DrawBoard(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));

            for (int i = 0; i < player.GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < player.GameBoard.GetLength(1); j++)
                {
                    Console.Write($" {player.GameBoard[i, j]} ");
                }

                Console.WriteLine("\n");
            }
        }
    }
}
