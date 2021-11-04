using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;

namespace Battleships.Logic.BoardLogic
{
    //pierwsze wygeneruj statki jako 1 w tablicy zer, później dopiero wyświetl.
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

        public void PointTypeDraw(DrawType draw, Cell cell)
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

//var first = FirstPosition();
//table[first.X, first.Y] = 1;

//public void DrawShips()
//{
//    var firstSpot = FirstPosition()


//    foreach (var ship in Ships)
//    {
//        PlaceShipOnBoard(firstSpot, ship);
//        FindNextSpot();
//    }
//}

////metoda gdzie dostajesz punkt wygenerowany
//public Cell DrawPointOnBoard(Cell cell)
//    => board[cell.X, cell.Y] = 1;

//public void DrawHitOrMissOnBoard(Cell cell)
//{
//    var res = ReturnHitOrMiss(cell)


//    switch draw
//    {
//        draw.Hit = board[cell.X, cell.Y] = 2,
//        draw.Miss = board[cell.X, cell.Y] = 3,
//        draw.Ship = board[cell.X, cell.Y] = 1,
//    }


