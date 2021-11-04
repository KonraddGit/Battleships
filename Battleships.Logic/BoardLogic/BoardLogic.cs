using System;

namespace Battleships.Logic.BoardLogic
{
    public static class Board
    {
        public static int[,] GameBoard = new int[10, 10];

        public static void DrawBoard()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    Console.Write($" {GameBoard[i, j]} ");
                }

                Console.WriteLine("\n");
            }
        }
    }
}
