using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;
using System.Threading.Tasks;

namespace Battleships.Logic.BoardLogic
{
    //ten sam algorytm do generowania statkow i strzelania,
    //jakis wzorzec do konstruowania obiektów
    public class CellLogic : ICell
    {
        private static readonly Random rnd = new();

        public Cell FirstPosition()
            => new Cell
            {
                X = rnd.Next(0, 10),
                Y = rnd.Next(0, 10),
            };

        public async Task PointTypeDraw(DrawType draw, Cell cell)
        {
            switch (draw)
            {
                case DrawType.Hit:
                    ShipHit(cell);
                    break;

                case DrawType.Miss:
                    ShipMiss(cell);
                    break;

                case DrawType.ShipMark:
                    ShipMark(cell);
                    break;
            }
        }

        public void ShipMark(Cell cell)
            => Board.GameBoard[cell.X, cell.Y] = 1;
        public void ShipHit(Cell cell)
            => Board.GameBoard[cell.X, cell.Y] = 2;
        public void ShipMiss(Cell cell)
            => Board.GameBoard[cell.X, cell.Y] = 3;
    }
}
