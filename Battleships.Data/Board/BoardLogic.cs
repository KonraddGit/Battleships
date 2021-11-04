using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;

namespace Battleships.Logic.BoardLogic
{
    public class Board : IBoard
    {
        private readonly int[,] board = new int[10, 10];


        public void DrawBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {

                }
            }
        }
    }
}
