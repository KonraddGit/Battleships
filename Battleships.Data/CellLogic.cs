using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Logic
{
 //pierwsze wygeneruj statki jako 1 w tablicy zer, później dopiero wyświetl.
 //ten sam algorytm do generowania statkow i strzelania,
 //jakis wzorzec do konstruowania obiektów
    public class CellLogic : ICell
    {
        private static readonly Random rnd = new();

        public static Cell FirstPosition()
            => new Cell
            {
                X = rnd.Next(0, 10),
                Y = rnd.Next(0, 10),
            };

        var first = FirstPosition();
        table[first.X, first.Y] = 1;

        public void DrawShips()
        {
            var firstSpot = FirstPosition()


            foreach (var ship in Ships)
            {
                PlaceShipOnBoard(firstSpot, ship);
                FindNextSpot();
            }
        }

        //metoda gdzie dostajesz punkt wygenerowany
        public Cell DrawPointOnBoard(Cell cell)
            => board[cell.X, cell.Y] = 1;

        public void DrawHitOrMissOnBoard(Cell cell)
        {
            var res = ReturnHitOrMiss(cell)


            switch draw
            {
                draw.Hit = board[cell.X, cell.Y] = 2,
                draw.Miss = board[cell.X, cell.Y] = 3,
                draw.Ship = board[cell.X, cell.Y] = 1,
            }
    }

    public enum DrawType
    {
        Hit = 0,
        Miss = 1,
        Ship = 2
    }
}
}
