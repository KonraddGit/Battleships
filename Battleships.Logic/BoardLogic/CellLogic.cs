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

        public Cell PointTypeDraw(DrawType draw, Cell cell)
        {
            switch (draw)
            {
                case DrawType.Hit:
                    return ShipHit(cell);

                case DrawType.Miss:
                    return ShipMiss(cell);

                case DrawType.ShipMark:
                    return ShipMark(cell);
            }

            return cell;
        }

        public Cell ShipMark(Cell cell)
        {
            Board.GameBoard[cell.X, cell.Y] = 1;
            return cell;
        }

        public Cell ShipHit(Cell cell)
        {
            Board.GameBoard[cell.X, cell.Y] = 2;
            return cell;
        }

        public Cell ShipMiss(Cell cell)
        {
            Board.GameBoard[cell.X, cell.Y] = 3;
            return cell;
        }
    }
}