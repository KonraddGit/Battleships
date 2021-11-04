using Battleships.Core.Interfaces;
using Battleships.Logic.BoardLogic;

namespace Battleships.Logic
{
    public class Simulation
    {
        public IBoard Board { get; set; }
        public ICell Cell { get; set; }
        public Simulation()
        {
            Board = new Board();
            Cell = new CellLogic();
        }

        public void Run()
        {

            Board.DrawBoard();
        }
    }
}
